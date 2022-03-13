using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlatformOld : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    public float rotationOffset;
    Vector2 lastClickedPos;
    bool moving;


    void Update()
    {
        //activate other script
        if (Input.GetMouseButtonDown(1)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetMouseButtonDown(1)) GetComponent<SwordPlatformOld>().enabled = false;
        if (Input.GetMouseButtonDown(1)) GetComponent<SwordMovementOld>().enabled = true;

        //Box collider on
        GetComponent<Collider2D>().enabled = true;

        //Throw sword
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        }
        else
        {
            moving = false;
        }
    }
}