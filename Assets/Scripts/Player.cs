using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    private float Horizontal;
    private Rigidbody2D ridigbody2D;
    private SpriteRenderer spriteRenderer;
    private bool Grounded;
    public bool playerOne;
    public bool red, blue;
    
    public float movementDirection = 0.0f;
    private bool move;

    public float posXCP;
    public float posYCP;

    public bool blocked;
    public bool leftBlock, rightBlock;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ridigbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection=0;

        if(playerOne){
            Horizontal = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.A)){
                if(Horizontal < 0.0f) spriteRenderer.flipX = false;
                movementDirection = -1.0f;
                
            }
            else if (Input.GetKey(KeyCode.D)){
                if (Horizontal > 0.0f) spriteRenderer.flipX = true;
                movementDirection = 1.0f;
            }
        }
        else{
            Horizontal = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.LeftArrow)){
                if(Horizontal < 0.0f) spriteRenderer.flipX = false;
                movementDirection = -1.0f;
                
            }
            else if (Input.GetKey(KeyCode.RightArrow)){
                if (Horizontal > 0.0f) spriteRenderer.flipX = true;
                movementDirection = 1.0f;
            }
        }
        
        
        //animator.SetBool("isRunning", Horizontal != 0.0f);

        //animator.SetBool("isJumping", !Grounded);

        float rayDistance = 1.3f;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);
        Debug.Log(raycast.collider);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        if (raycast.collider != null)
        {
            Grounded = true;
            //Debug.Log(Grounded);
        }
        else Grounded = false;

        // Salto
        if(playerOne){
            if (Input.GetKeyDown(KeyCode.W) && Grounded)
            {
                Jump();
            }
        }
        else{
            if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
            {
                Jump();
            }
        }

        //checkpoint
        if(Input.GetKeyDown(KeyCode.R)){
            transform.position = new Vector2(posXCP, posYCP);
        }

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
/*
(1 << 3) | (1 << 5)

*/

    private void Jump(){
        ridigbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate(){
        if(!blocked){
            ridigbody2D.velocity = new Vector2(movementDirection*Speed, ridigbody2D.velocity.y);
        }
        else{
            if(leftBlock && movementDirection == 1.0f){
                ridigbody2D.velocity = new Vector2(movementDirection*Speed, ridigbody2D.velocity.y);
                blocked = false;
                leftBlock = false;
            }
            else if(rightBlock && movementDirection == -1.0f){
                ridigbody2D.velocity = new Vector2(movementDirection*Speed, ridigbody2D.velocity.y);
                blocked = false;
                rightBlock =false;
            }
            
            
            
        }
    } 

}
