using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlatform : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        if (Input.GetKeyDown(KeyCode.M)) //change tghis so if the player is facing a certain way
        {
            PlatformLeft();
        }

    }

    void PlatformLeft()
    {
        transform.eulerAngles = new Vector3(0, 0, 90);
    }
}
