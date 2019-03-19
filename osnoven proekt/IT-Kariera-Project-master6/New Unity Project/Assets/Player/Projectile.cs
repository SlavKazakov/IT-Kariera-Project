using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float timer;
    public int damage = 40; 

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    { //after 1.2 sec the projectile disappears
        timer += 1.0F * Time.deltaTime;
        if (timer >= 1.2)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
         EnemyPatrol enemy =hitInfo.GetComponent<EnemyPatrol>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);

        EnemyFollow enemy1 = hitInfo.GetComponent<EnemyFollow>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
        }

        Destroy(gameObject);

        EnemyAttack enemy2 = hitInfo.GetComponent<EnemyAttack>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }

        Destroy(gameObject);

        EnemyShoot enemy3 = hitInfo.GetComponent<EnemyShoot>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
    
}
