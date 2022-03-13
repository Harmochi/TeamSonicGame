using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovementOld : MonoBehaviour
{
    [SerializeField] private GameObject magnet;
    [SerializeField] private float speed = 1.5f;

    void Start()
    {
        GetComponent<SwordPlatformRight>().enabled = false;
        GetComponent<SwordPlatformLeft>().enabled = false;
    }


    void Update()
    {
        GetComponent<Collider2D>().enabled = false;

        //activate other script
        if (Input.GetKeyDown(KeyCode.H)) transform.eulerAngles = new Vector3(0, 0, 90);
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordPlatformLeft>().enabled = true;
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordMovementOld>().enabled = false;

        if (Input.GetKeyDown(KeyCode.K)) transform.eulerAngles = new Vector3(0, 0, 270);
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordPlatformRight>().enabled = true;
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordMovementOld>().enabled = false;

        //Following
        transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, speed * Time.deltaTime);
    }
}
