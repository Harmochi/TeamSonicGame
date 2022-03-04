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

    [Header("Dashing")]
    public float dashDistance = 15f;
    bool isDashing;

    public Animator animator;

    //Gravity reset 
    private void Start()
    {
        rb.gravityScale = 5f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Dashing 
      if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash(-1f));
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash(1f));
        }

        //Player Move left and right
        mx = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(mx));

        //Jumping Code
        if (Input.GetButtonDown("Jump"))
        {
            //animator.SetTrigger("isJumping");
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
        if(!isDashing)
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

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        animator.SetTrigger("Dash");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        rb.gravityScale = 5;
    }

}