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
        GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        //Flip (not needed rn)??
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

        //Switch Between Codes And Rotate
        if (Input.GetKeyDown(KeyCode.H)) transform.eulerAngles = new Vector3(0, 0, 90);
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordPlatformLeft>().enabled = true;
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordMovement>().enabled = false;

        if (Input.GetKeyDown(KeyCode.K)) transform.eulerAngles = new Vector3(0, 0, 270);
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordPlatformRight>().enabled = true;
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordMovement>().enabled = false;
    }

}
