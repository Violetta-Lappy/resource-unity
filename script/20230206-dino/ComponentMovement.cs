using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ComponentMovement : MonoBehaviour
{
    [Range(0,100)] public float f_jumpForce = 1f;
    [Range(0, 100)] public float f_gravity = 1f;

    public int i32_holdJumpMultiplier = 2;

    Vector3 vec3_direction = new Vector3();

    Transform m_Transform;
    Rigidbody m_Rigidbody;
    ComponentCollisionResponse m_CollisionResponse;
    public ComponentAnimatorAOC m_animator;

    public bool isJumping = false;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Transform = this.transform;
        m_Rigidbody = this.GetComponent<Rigidbody>();
        m_CollisionResponse = this.GetComponent<ComponentCollisionResponse>();

        f_jumpForce = ProjectConstants.K_DINO_JUMPFORCE;
        f_gravity = ProjectConstants.K_DINO_GRAVITY;
        i32_holdJumpMultiplier = ProjectConstants.K_DINO_HELD_JUMP_MULTIPLIER;
    }

    // Fixed update
    void FixedUpdate()
    {
        //Add gravity to the direction the player is moving in
        vec3_direction += Vector3.down * f_gravity * Time.deltaTime;

        //Check if player is on ground
        if (isGrounded == true) 
        {
            //Reset gravity to Vector3.down to have a consistence jump height
            vec3_direction = Vector3.down;

            //Check if player should be jumping...
            if (isJumping) 
            {
                //... set isGrounded to false since it should jump...
                isGrounded = false;

                //... then set the direction to be going upward with jump force.
                vec3_direction = Vector3.up * f_jumpForce;

                //SFX
                ManagerAudio.Instance.PlayGameSFX("jump");
            }
        }
        else
        {
            //If player still holds jump THEN add a bit of upward force to player so they jump higher + fall down slower.
            if (isJumping) vec3_direction += Vector3.up * Time.deltaTime * f_jumpForce * i32_holdJumpMultiplier;
        }

        //Move player to the direction calculated
        m_Rigidbody.MovePosition(this.transform.position + vec3_direction * Time.deltaTime);
    }

    public void SetIsJumping(bool jumpState)
    {
        isJumping = jumpState;
    }

    public void SetIsGrounded(bool groundState)
    {
        isGrounded = groundState;

        if (isGrounded) m_animator.PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE.RUN);
    }

}
