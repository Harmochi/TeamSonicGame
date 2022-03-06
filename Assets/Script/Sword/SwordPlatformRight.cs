using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlatformRight : MonoBehaviour
{

    [SerializeField] private float speed = 4f;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
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
        if (Input.GetKeyDown(KeyCode.K)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordPlatformRight>().enabled = false;
        if (Input.GetKeyDown(KeyCode.K)) GetComponent<SwordMovement>().enabled = true;
    }

}
