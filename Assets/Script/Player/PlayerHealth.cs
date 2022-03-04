using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    private bool hasEntered;
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == ("Death") && !hasEntered)
        {
            SceneManager.LoadScene("Level 1");
        }

        if (collision.gameObject.tag == ("Enemy") && !hasEntered)
        {
            TakeDamage(1);


            void TakeDamage(int damage)
            {
                currentHealth -= damage;

                healthBar.SetHealth(currentHealth);

                Death();
            }
        }
    }



    public void Death()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level 1");
    
        }
    }
}
