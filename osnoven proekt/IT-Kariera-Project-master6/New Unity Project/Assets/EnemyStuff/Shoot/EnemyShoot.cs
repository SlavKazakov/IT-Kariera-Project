using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float num;

    private Transform target;
    public int health = 100;
    public GameObject projectile;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        if (transform.position.x - target.transform.position.x < num && transform.position.x - target.transform.position.x >= 0)
        {

            if (timeBtwShots <= 0)
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
                num = 20;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else if (transform.position.x - target.transform.position.x > -num && transform.position.x - target.transform.position.x <= 0)
        {
            if (timeBtwShots <= 0)
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
                num = 20;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
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

    public Transform firePoint;
    


    void Shoot()
    {

        //shooting logic
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
