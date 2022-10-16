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
    
    float movementDirection;
    private GameObject cursor;
    private bool move;

    public float posXCP;
    public float posYCP;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ridigbody2D = GetComponent<Rigidbody2D>();
        cursor = GameObject.FindWithTag("cursor");
    }

    void Update()
    {
        movementDirection=0;

        if(Input.GetKeyDown(KeyCode.Space)){
            cursorActivation(); 
        }

        if(playerOne){
            Horizontal = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.A)){
                if(Horizontal < 0.0f) spriteRenderer.flipX = true;
                movementDirection = -1.0f;
                
            }
            else if (Input.GetKey(KeyCode.D)){
                if (Horizontal > 0.0f) spriteRenderer.flipX = false;
                movementDirection = 1.0f;
            }
        }
        else{
            Horizontal = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.LeftArrow)){
                if(Horizontal < 0.0f) spriteRenderer.flipX = true;
                movementDirection = -1.0f;
                
            }
            else if (Input.GetKey(KeyCode.RightArrow)){
                if (Horizontal > 0.0f) spriteRenderer.flipX = false;
                movementDirection = 1.0f;
            }
        }
        
        
        //animator.SetBool("isRunning", Horizontal != 0.0f);

        float rayDistance = 1.0f;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);
        Debug.Log(raycast.collider);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        if (raycast.collider != null)
        {
            Grounded = true;
            //Debug.Log(Grounded);
        }
        else Grounded = false;

        //animator.SetBool("isJumping", !Grounded);

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

    private void Jump(){
        ridigbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate(){
        ridigbody2D.velocity = new Vector2(movementDirection*Speed, ridigbody2D.velocity.y);
    } 

    private void cursorActivation(){
        if(cursor.GetComponent<Renderer>().enabled == false){
            cursor.GetComponent<Renderer>().enabled = true;
            cursor.transform.position = new Vector2(transform.position.x, transform.position.y);
            move = false;
        }
        else{
            cursor.GetComponent<Renderer>().enabled = false;
            move = true;
        }
        
        Debug.Log(!(gameObject.GetComponent<Renderer>().enabled));
    }
}
