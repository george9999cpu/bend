using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
     public float jumpHeight;
    public KeyCode L;
     public KeyCode R;
     public KeyCode spaceBar;
     public Transform groundCheck;
     public float groundCheckRadius;
     private bool grounded;
     public LayerMask whatIsGround;
     private Animator anim;
     private Rigidbody2D rb;
     private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
          rb = GetComponent<Rigidbody2D>();
          sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {



anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
anim.SetFloat("Height", rb.velocity.y);
anim.SetBool("Grounded", grounded);
Debug.Log("Speed: " + rb.velocity.x + " | grounded: " + grounded);

        
if (Input.GetKey(L)){
  rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
if (sr != null){
sr.flipX = true;
}
}
    
if (Input.GetKey(R)){
  rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
if (sr != null){
sr.flipX = false;
}
}

if (Input.GetKeyDown(spaceBar) && grounded){
 jump();
}





        
}



void jump(){
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }


void FixedUpdate(){
grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);}
}
