using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput; //detect keys

    private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    public float health = 100;

    public GameObject gameOverText, restartButton;

    public float damage;

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }
    
    
    private void FixedUpdate()
    {
        //Grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        //movement
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);

        //flipping left and right
        if(facingRight==false && moveInput > 0)
        {
            Flip();
        }else if(facingRight==true && moveInput < 0)
        {
            Flip();
        }
        if (rb.position.y <= -6f)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    
    //jumping
    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded==true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    //flip function
    void Flip()
    {
        facingRight =! facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyAttack enemyAttack = collision.collider.GetComponent<EnemyAttack>();
        EnemyFollow enemyFollow = collision.collider.GetComponent<EnemyFollow>();
        EnemyPatrol enemyPatrol = collision.collider.GetComponent<EnemyPatrol>();
        EnemyShoot enemyShoot = collision.collider.GetComponent<EnemyShoot>();

        if (health <= 0 || enemyPatrol != null || enemyAttack != null || enemyFollow != null || enemyShoot != null) 
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    public void TakeRangedDamage(int damageRanged)
    {
        health -= damageRanged;
        if (health <= 0 )
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }   
    
}
