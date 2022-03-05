using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    [SerializeField] private GameObject magnet;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        GetComponent<SwordPlatform>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 0;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    void Update()
    {
        //Flip??
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

        //Following
        transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordPlatform>().enabled = true;
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordMovement>().enabled = false;
    }

}
