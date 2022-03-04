using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private PlayerHealth playerhealth;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack when player is in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //Attack
                cooldownTimer = 0;
                //when u have animation: anim.SetTrigger("whateverthenameis");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerhealth = hit.transform.GetComponent<PlayerHealth>();

        return hit.collider !=null;
    }

    //colour??
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    
    private void DamagePlayer()
    {
        //If player is still in range, damage him
        if (PlayerInSight())
        {
            //this needs to get fixed
        }
    }
}
