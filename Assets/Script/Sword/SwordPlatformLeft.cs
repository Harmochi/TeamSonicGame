using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlatformLeft : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-2f, 0f);
    }



    //Switch between scripts
    public void Update()
    {
        GetComponent<Collider2D>().enabled = true;

        if (Input.GetKeyDown(KeyCode.H)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordPlatformLeft>().enabled = false;
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordMovementOld>().enabled = true;
    }

}
