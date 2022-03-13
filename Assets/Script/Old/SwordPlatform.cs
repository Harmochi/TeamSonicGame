using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //change tghis so if the player is facing a certain way
        if (Input.GetAxis("Horizontal") == -1)
        {
            PlatformLeft();
            Debug.Log("Activate left");
        }

        if (Input.GetAxis("Horizontal") == 1)
        {
            PlatformRight();
            Debug.Log("Activate right");
        }
    }

    //Move sword that direction 
    void PlatformLeft()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 90;
        transform.rotation = Quaternion.Euler(rotationVector);

    }

    void PlatformRight()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 270;
        transform.rotation = Quaternion.Euler(rotationVector);
    }


    //Detect floor 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flooring"))
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }

    //Switch between scripts
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordPlatform>().enabled = false;
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordMovement>().enabled = true;
    }

}
