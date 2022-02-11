using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
    enum DashDirection
    {
        Left,
        Right,
        NoDirection
    }

    Rigidbody2D body;
    public float speed;
    public float dashSpeed;
    private DashDirection dashDirection;
    public float dashDuration;
    public float dashTimer;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        dashDirection = DashDirection.NoDirection;
    }

    void Update()
    {
        body.velocity = Vector2.zero;
        {
            dashDirection = DashDirection.Left;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            dashDirection = DashDirection.Right;
        }
        if (dashDirection != DashDirection.NoDirection)
        {
            if (dashTimer >= dashDuration)
            {
                dashDirection = DashDirection.NoDirection;
                dashTimer = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                dashTimer += Time.deltaTime;
                if (dashDirection == DashDirection.Left)
                {
                    body.velocity = Vector2.left * dashSpeed;
                }

                if (dashDirection == DashDirection.Right)
                {
                    body.velocity = Vector2.right * dashSpeed;
                }

            }

        }

    }
}