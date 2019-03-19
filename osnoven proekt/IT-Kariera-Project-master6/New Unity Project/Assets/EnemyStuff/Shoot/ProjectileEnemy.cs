using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed = 5f;

    private Transform player;
    private Vector2 target;
    public float timer;
    public int damage = 40;
    public Rigidbody2D rb;
    public Transform EnemyAt;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyAt = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Transform>();
        target = new Vector2(player.position.x, player.position.y);
    }
    void Update()
    {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);  
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }

        
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if ( player!= null)
        {
            player.TakeRangedDamage(damage);
            Destroy(gameObject);
        }
    }
    

}
