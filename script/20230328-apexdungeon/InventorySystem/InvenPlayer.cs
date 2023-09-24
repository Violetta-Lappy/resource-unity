using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenPlayer : MonoBehaviour
{

    [SerializeField] Inventory inventoryMod;
    [SerializeField] Inventory inventoryCon;

    public float speed = 5.0f;
    public float speedMultiplier = 10.0f;
    public float speedAir = 0.5f;
    private float horizontal;
    private float vertical;

    private bool isGrounded;

    Vector3 movingDirection;
    Rigidbody rigidBody;

    [SerializeField] GameObject canvas;
    private bool invenCanvasOn = false;


    // Start is called before the first frame update
    void Start()
    {
        //Get reference to rigidbody from Hierarchy
        rigidBody = GetComponent<Rigidbody>();

        //Freeze rotation
        rigidBody.freezeRotation = true;

        canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (invenCanvasOn)
            {
                canvas.SetActive(false);
                invenCanvasOn = false;
                Time.timeScale = 1;
            }
            else
            {
                canvas.SetActive(true);
                invenCanvasOn = true;
                Time.timeScale = 0;

            }
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            if(other.GetComponent<PickUp>().item.itemType == ItemType.consumable)
            {
                if (inventoryCon.AddItem(other.GetComponent<PickUp>().item))
                {
                    Destroy(other.gameObject);
                }
            } else if(other.GetComponent<PickUp>().item.itemType == ItemType.modify)
            {        
                if (inventoryMod.AddItem(other.GetComponent<PickUp>().item))
                {
                    Destroy(other.gameObject);
                }
            }
 
        }
    }
}
