using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play Attack Animation
        animator.SetTrigger("Player_Attacking");

        //Detect Enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Damage Enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(" We hit " + enemy.name);
        }
    }
}
