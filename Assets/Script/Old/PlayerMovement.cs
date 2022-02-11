using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour

{
    bool isDashing;
    bool isGrounded;
    float doubleTapTime;
    float mx;
    float jumpCoolDown;
    public float speed = 10f;
    public float jumpPower = 15f;
    public float dashDistance = 15f;
    public int extraJumps = 1;
   

    [SerializeField] public LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    int jumpCount = 0;
    KeyCode lastKeyCode;

    void Start()
    {
        
    }


    void Update()
    {
        //Movement
        mx = Input.GetAxis("Horizontal");

        //Dash Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
            } else
            {
                doubleTapTime = Time.time + 0.05f;
            }

            lastKeyCode = KeyCode.A;
        }

        //Dash Right
        if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.05f;
            }

            lastKeyCode = KeyCode.D;
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    IEnumerator Dash (float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
}
