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

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
      
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
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
