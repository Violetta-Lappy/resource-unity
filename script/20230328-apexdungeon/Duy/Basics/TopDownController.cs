using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/****************************************************************************************************************************
Author: Pham Cong Duy
Date Made: 06/09/2021
Object(s) holding this script: Player
Summary: 
Handles player's movements 
*****************************************************************************************************************************/

public class TopDownController : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    [Header("Animations")]
    public Animator characteAnimator;
    public string idleAnim;
    public string moveAnim;
    public string attackAnim;

    [Header("Movement Variables")]
    public float speed = 5.0f;
    public float speedMultiplier = 10.0f;
    public float speedAir = 0.5f;
    public float dragGround = 5.0f;
    public float dragAir = 2.0f;
    public float gravitationalPull;
    public Transform groundCheck;
    public LayerMask groundMask;
    
    private float height = 2.0f;
    private float horizontal;
    private float vertical;

    private bool isGrounded;
    private bool invenCanvasOn;
    private bool canMove = true;    
    
    public GameObject lookAhead;
    public GameObject playerModel;

    Vector3 movingDirection;

    
    [Header("Components")]
    Rigidbody rigidBody;

    [Header("Dash")]
    public float dashResetTimer = 2f;
    public Slider dashSlider;
    private PlayerHealth playerHealth;
    private float currentDashTimer;
    private bool canDash = true;
    
    void Start()
    {
        //Get reference to rigidbody from Hierarchy
        rigidBody = GetComponent<Rigidbody>();

        //Freeze rotation
        rigidBody.freezeRotation = true;

        height = GetComponent<CapsuleCollider>().height;

        inventory.SetActive(false);

        playerHealth = GetComponent<PlayerHealth>();

        //Locking mouse 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        MovementInputs();
        GravityPull();
        
        //cast a sphere to check grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, .35f, groundMask);

        //RotatePlayerModel();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            HandleInventory();
        }

        Rotate(playerModel.transform);

        //To fix the bug where player can run up on to prop colliders
        HandleSlope();
        
        HandleDash();
    }

    void HandleSlope()
    {
        var origin = transform.position + new Vector3(0, height * 0.4f, 0);

        Debug.DrawRay(origin, movingDirection.normalized * 10, Color.white);

        if(Physics.SphereCast(origin, .15f, movingDirection.normalized, out RaycastHit hit, 2))
        {
            if(hit.rigidbody == null && !hit.collider.isTrigger)
            {
                //Debug.Log("Collide");
                canMove = false;
            }
        }
        else
        {
            canMove = true;
        }
    }

    public void HandleInventory()
    {
        if (invenCanvasOn)
        {
            inventory.SetActive(false);
            invenCanvasOn = false;
            Time.timeScale = 1;
        }
        else
        {
            inventory.SetActive(true);
            invenCanvasOn = true;
            Time.timeScale = 0;
        }
    }

    void RotatePlayerModel()
    {
        playerModel.transform.forward = lookAhead.transform.forward;
    }

    void Rotate(Transform whatToRotate)
    {
        Vector3 rotateDir = new Vector3(lookAhead.transform.position.x, playerModel.transform.position.y, lookAhead.transform.position.z) - whatToRotate.position;
        rotateDir.Normalize();
        float angle = Vector3.SignedAngle(transform.forward, rotateDir, Vector3.up);

        Debug.DrawRay(whatToRotate.position, playerModel.transform.forward * 5, Color.yellow);
        //Debug.DrawRay(whatToRotate.position, rotateDir * 5, Color.blue);
        
        whatToRotate.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
    
    void FixedUpdate()
    {
        //Get called here for smoother movement 
        MovePlayer();
    }

    //Checks for inputs
    //Called by Update()
    void MovementInputs()
    {
        //Get horizontal and vertical movement
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //To move in the direction relative to where looking
        movingDirection = transform.forward * vertical + transform.right * horizontal;
        
            
        if (horizontal != 0 || vertical != 0)
        {
            characteAnimator.Play(moveAnim);
        }
        else
        {
            characteAnimator.Play(idleAnim);
        }
    }

    //Move player smoothly, added speedMultiplier to counter the gravity drag
    //Called in FixedUpdate()
    void MovePlayer()
    {
        if (!canMove) return;

        if (isGrounded)
        {
            rigidBody.AddForce(movingDirection.normalized * speed * speedMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rigidBody.AddForce(movingDirection.normalized * speed * speedMultiplier * speedAir, ForceMode.Acceleration);
        }
    }

    void HandleDash()
    {
        if (canDash)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (movingDirection != Vector3.zero)
                {
                    rigidBody.AddForce(movingDirection.normalized * 65, ForceMode.Impulse);
                }
                else
                {
                    rigidBody.AddForce(transform.forward * 65, ForceMode.Impulse);
                }
                currentDashTimer = dashResetTimer;
                canDash = false;
                dashSlider.value = 0;
                StartCoroutine(IFrameRoutine());

                AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_TYPE.GUN);
            }
        }
        else
        {
            if (currentDashTimer > 0)
            {
                currentDashTimer -= Time.deltaTime;
                dashSlider.value += Time.deltaTime;
            }
            else
            {
                dashSlider.value = 2;
                canDash = true;
            }
        }
    }

    IEnumerator IFrameRoutine()
    {
        playerHealth.canReceiveDamage = false;
        yield return new WaitForSeconds(.5f);
        playerHealth.canReceiveDamage = true;
    }


    //Without this drag player will be floating towards the direction pressed
    //Later if needed for jumping
    //Called in Update()
    void GravityPull()
    {
        if (isGrounded)
        {
            rigidBody.drag = dragGround;
        }
        else
        {
            rigidBody.drag = dragAir;
            rigidBody.AddForce(Vector3.down * gravitationalPull, ForceMode.Acceleration);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheck.position, .35f);
    }
}
