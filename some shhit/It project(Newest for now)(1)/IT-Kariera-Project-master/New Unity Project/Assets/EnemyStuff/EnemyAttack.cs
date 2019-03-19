using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed;
    public float num;
    public Transform EnemyAt;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyAt = GameObject.FindGameObjectWithTag("Ai").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyAt.transform.position.x - target.transform.position.x >0.2)
        {
            if (EnemyAt.transform.position.x - target.transform.position.x < num && EnemyAt.transform.position.x - target.transform.position.x >= 0)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                num = 20;
            }
           
        }
        else
        {
            if (target.transform.position.x > EnemyAt.transform.position.x)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            }
        }
        
    }

    public int health = 100;

    public GameObject deathEffect;

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
