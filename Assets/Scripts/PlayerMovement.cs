using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2;

    [Header("Movement Variables")]
    public float m_moveSpeed = 7.5f;
    public float movementMultiplier = 10.0f;
    public float jumpSpeed;


    [SerializeField] Transform orientation;

    Vector2 movement;


    private Vector3 moveDirection;

    private float rbDrag = 14;

    float groundDistance = 0.4f;

    private Rigidbody rb;

    bool isGrounded;

    RaycastHit slopeCast;

    Vector3 slopeMoveDirection;

    private void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }


    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position,Vector3.down,out slopeCast,playerHeight/2+0.5f))
        {
            if(slopeCast.normal!=Vector3.up) //On a slope
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        return false;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down,playerHeight/2+0.1f);
        //isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance);
        CollectInput();
        ControlDrag();

        if(Input.GetKeyDown(KeyCode.Space) &&isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpSpeed,ForceMode.Impulse);

        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeCast.normal);
    }

    private void FixedUpdate()
    {
        MovePlayer();

        //Mine
        if(isGrounded &&movement.magnitude>0)
        {

            //rb.AddForce(-rb.velocity * 0.1f, ForceMode.Acceleration);
        }
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = rbDrag;
            //stops the player from sliding down a small angle slope
            if (moveDirection.magnitude == 0 && OnSlope())
            {
                float slopeAngle = Vector3.Angle(slopeCast.normal, Vector3.up);
                if (slopeAngle < 50)
                {
                    rb.drag = 35;
                }
            }
        }
        else
        {
            rb.drag = 1;
        }

        
    }

    private void CollectInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        moveDirection = orientation.forward * movement.y + orientation.right * movement.x;
        //moveDirection = transform.forward * movement.y + transform.right * movement.x;
    }

    private void MovePlayer()
    {
        if (isGrounded&& !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * m_moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if(isGrounded&& OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * m_moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if(!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * (m_moveSpeed/rbDrag) * movementMultiplier, ForceMode.Force);
        }

       

    }

}
