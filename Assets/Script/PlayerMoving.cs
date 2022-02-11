using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{

    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;

    int jumpCount = 0;
    bool isGrounded;
    float mx;
    float jumpCoolDown;

    private void Update()
    {
        mx = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }
}
