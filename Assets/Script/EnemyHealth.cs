using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    private bool hasEntered;
    public int maxHealth = 2;
    public int currentHealth;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public CircleCollider2D cc;


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
    }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Debug.Log("Enemy died!");

        Destroy(rb);
        Destroy(sr);
        Destroy(cc);
        this.enabled = false;
        
        }
    
}