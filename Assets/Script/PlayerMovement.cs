using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public PlayerCollision controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    //Scripts can grab this
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Jumping
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Crouch

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
