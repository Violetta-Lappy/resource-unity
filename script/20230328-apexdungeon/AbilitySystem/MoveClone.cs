using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClone : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedMultiplier = 10.0f;
    public float speedAir = 0.5f;
    public float dragGround = 5.0f;
    public float dragAir = 2.0f;

    private float height = 2.0f;
    private float horizontal;
    private float vertical;

    private bool isGrounded;

    public GameObject lookAhead;
    public GameObject baseWeapon;

    Vector3 movingDirection;
    public Vector3 lastMoveDirection;
    Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        //Get reference to rigidbody from Hierarchy
        rigidBody = GetComponent<Rigidbody>();

        //Freeze rotation
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
        GravityPull();

        //Checks for ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.1f);

        //Follow mouse
        baseWeapon.transform.LookAt(new Vector3(lookAhead.transform.position.x, transform.position.y, lookAhead.transform.position.z));
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
        
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
        lastMoveDirection = movingDirection;
        }

    }

    //Move player smoothly, added speedMultiplier to counter the gravity drag
    //Called in FixedUpdate()
    void MovePlayer()
    {
        if (isGrounded)
        {
            rigidBody.AddForce(movingDirection.normalized * speed * speedMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rigidBody.AddForce(movingDirection.normalized * speed * speedMultiplier * speedAir, ForceMode.Acceleration);
        }

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
        }
    }
}
