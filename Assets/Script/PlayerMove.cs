using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10f;
    public float jumpPower = 15f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    bool isGrounded;
    float mx;
    float jumpCoolDown;
    KeyCode lastKeyCode;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public Animator animator;

    //Gravity reset 
    private void Start()
    {
        rb.gravityScale = 5f;
        dashTime = startDashTime;
    }

    public void Update()
    {
        //Dashing 
        if (Input.GetKeyDown(KeyCode.LeftShift)) //add stam with &&
            PlayerStamina.instance.UseStamina(1);
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = 1;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                direction = 2;
            }
        }

        if (dashTime <= 0) //if stamina 
        {
            dashTime = startDashTime;

        }

        //forgot lol
        mx = Input.GetAxis("Horizontal");

        //Jumping Code
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //Flip Character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        CheckGrounded();
    }

    //Speed
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    //Jumping
    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    //Checks if grounded
    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCoolDown = Time.time + 0.01f;
        }
        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}