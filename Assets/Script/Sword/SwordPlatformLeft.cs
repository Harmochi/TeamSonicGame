using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlatformLeft : MonoBehaviour
{

    public float speed;
    public float translationY;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D bc;
    [SerializeField] private Transform Sword;

    //Detect floor 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flooring"))
        {
            this.rb.velocity = Vector3.zero;
            GetComponent<Collider2D>().enabled = true;
        }
    }

    //Switch between scripts
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordPlatformLeft>().enabled = false;
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<SwordMovement>().enabled = true;
    }

}
