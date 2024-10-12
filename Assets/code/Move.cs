using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class hareket : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator ar;
    BoxCollider2D bc;
    public Transform groundCheck;
    move1 mv1;

    public LayerMask IsGround;
    public LayerMask Walllayer;

    private int PDirection = 1;

    
    public float horizontal;
    public float speed = 500;
    public float jumpforce = 5;
    public float extrajump;
    public float extrajumpValue = 1;
    public float wallslidespeed;
    public float jumpheight;
    public float ForceInAir;
    public float airDragMultiplier;
    public float wallHopForce;
    public float wallJumpForce;
    public float groundCheckRadius;
   

    public float turnTimer;
    public float turnTimerSet;
    public float JumpTimer;
    public float JumpTimerSet;

    public bool canMove;
    public bool canFlip;

    public Vector2 knockBack;
    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;
   
    void Start()
    {
        mv1 = GetComponent<move1>();
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();

        ControlMove(true);



    }


    void Update()
    {
      
       
        ar.SetFloat("Jump", rb.velocity.y);
        
        Jump();
        Flip();
       

    
        ar.SetBool("Grounded", IsGrounded());



        move();
        Canflip();
        Canjump();



    }
    public void Canjump()
    {
        if (!IsGrounded() && !OnWall())
        {
            JumpTimer = JumpTimerSet;
        }
        else if (IsGrounded() && !OnWall())
        {
            
            
            JumpTimer -= Time.deltaTime;
            
            
        }
        
        if (JumpTimer < 0)
        {
            extrajump = extrajumpValue;
            JumpTimer = 0;
        }
    }
    public void Canflip()
    {
        if (Input.GetButtonDown("Horizontal") && OnWall())
        {
            if (!IsGrounded() && horizontal != 0)
            {

                canFlip = false;

                turnTimer = turnTimerSet;
            }
        }

        if (!canFlip)
        {
            turnTimer -= Time.deltaTime;

            if (turnTimer <= 0)
            {

                canFlip = true;
            }
        }

        if (!canMove)
        {
            ar.SetBool("run", false);
        }
    }
    public void ControlMove(bool can)
    {
        if (can)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }
    private void FixedUpdate()
    {
        
        //move();


    }

    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded() && canMove && horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            ar.SetBool("run", horizontal != 0);
        }
        else if(!IsGrounded() && !OnWall() && horizontal != 0)
        {
            Vector2 forceToAdd = new Vector2(ForceInAir * horizontal, 0);
            rb.AddForce(forceToAdd);

            if (Mathf.Abs(rb.velocity.x) > speed)
            {
                rb.velocity = new Vector2(speed * horizontal,rb.velocity.y);
            }
        }
        else if(!IsGrounded() && !OnWall() && horizontal == 0)
        {
            rb.velocity = new Vector2 (rb.velocity.x * airDragMultiplier,rb.velocity.y);
        }
     


        if (OnWall() && !IsGrounded() && rb.velocity.y < 0)
        {
            extrajump = 1;
            if (rb.velocity.y < -wallslidespeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallslidespeed);
                ar.SetBool("iswall", true);
            }
        }
        else
        {
            
            ar.SetBool("iswall", false);
        }

   
        
    }


    public void KnockBack()
    {
        ControlMove(false);
        //rb.velocity = Vector2.zero;
        rb.velocity =new Vector2(knockBack.x * -PDirection,rb.velocity.y + knockBack.y);
        //rb.AddForce(new Vector2(knockBack.x * -PDirection, rb.velocity.y + knockBack.y));
        StartCoroutine(Timer());
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        mv1.Duraktetik();

    }

    private void Flip()
    {
        if (!OnWall() && canFlip)
        {
            if (horizontal > 0.01f)
            {
                transform.localScale = new Vector3(6, 6, 6);
                PDirection = 1;
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-6, 6, 6);
                PDirection = -1;
            }
        }
    }
    private void Jump()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && extrajump > 0)
        {
            extrajump--;
            ar.SetBool("iswall", false);
            if (!OnWall())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                
            }
            else if (!IsGrounded() && OnWall() && horizontal != 0)
            {
                
                Vector2 forceToAdd = new Vector2(wallJumpDirection.x * wallJumpForce * -PDirection, wallJumpForce * wallJumpDirection.y);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            }

            else if (!IsGrounded() && OnWall() && horizontal == 0)
            {
                
                Vector2 forceToAdd = new Vector2(wallHopDirection.x * wallHopForce * -PDirection, wallHopForce * wallHopDirection.y);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            }
        

            ar.SetTrigger("jump");
           
            


        }
       
        
        /*
        else if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0 && extrajump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpheight);

        }
        */


    }
    
    public bool IsGrounded()
    {
        /*
        RaycastHit2D raycashit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, 0.1f,IsGround);
        return raycashit.collider != null;
        */
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, IsGround);
    }
    public bool OnWall()
    {
        
        RaycastHit2D raycashit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0,new Vector2(transform.localScale.x,0), 0.1f, Walllayer);
        return raycashit.collider != null;
        
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        
    }
}
