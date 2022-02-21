using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    private bool hasEntered;
    public int maxHealth = 2;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") && !hasEntered)
        {
            TakeDamage(1);
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;

        }
    }
}