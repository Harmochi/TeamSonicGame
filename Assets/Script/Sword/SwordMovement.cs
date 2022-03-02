﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    [SerializeField] private GameObject magnet;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {
        //Box collider
        GetComponent<Collider2D>().enabled = false;

        //Following
        transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, speed * Time.deltaTime);
    }

}