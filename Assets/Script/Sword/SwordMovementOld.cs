using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovementOld : MonoBehaviour
{
    [SerializeField] private GameObject magnet;
    [SerializeField] private float speed = 1.5f;

    void Start()
    {
        GetComponent<SwordPlatformOld>().enabled = false;
    }

    void Update()
    {

        //activate other script
        if (Input.GetMouseButtonDown(0)) transform.eulerAngles = new Vector3(0, 0, 270);
        if (Input.GetMouseButtonDown(0)) GetComponent<SwordPlatformOld>().enabled = true;
        if (Input.GetMouseButtonDown(0)) GetComponent<SwordMovementOld>().enabled = false;

        //Box collider
        GetComponent<Collider2D>().enabled = false;

        //Following
        transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, speed * Time.deltaTime);
    }
}
