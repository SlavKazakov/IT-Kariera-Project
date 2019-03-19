using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPlayer : MonoBehaviour
{
    public int damageRanged;

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            EnemyAttack.isAttacking = true;
            player.TakeRangedDamage(damageRanged);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            EnemyAttack.isAttacking = false;
        }
    }
}
