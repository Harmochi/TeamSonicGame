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
        if (collision.gameObject.tag == ("AttackPoint") && !hasEntered)
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

        Destroy(gameObject);

        this.enabled = false;

        //make it so seeker is disabled
        
        }
    
}