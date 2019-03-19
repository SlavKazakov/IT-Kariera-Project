using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed;
    public float num;
    public Transform EnemyAt;
    public int damage;

    private Transform target;

    public int health = 100;

    public GameObject deathEffect;

    public static bool isAttacking = false;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            if (transform.position.x - target.transform.position.x > 0.2)
            {
                if (transform.position.x - target.transform.position.x < num && transform.position.x - target.transform.position.x >= 0)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                    num = 20;
                }

            }
            else
            {
                if (target.transform.position.x > transform.position.x)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    //enemy death
    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
