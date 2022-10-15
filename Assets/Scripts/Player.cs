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
    
    float movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ridigbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection=0;

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
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            Debug.Log("jumping");
        }

    }

    private void Jump(){
        ridigbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate(){
        
        ridigbody2D.velocity = new Vector2(movementDirection*Speed, ridigbody2D.velocity.y);

    } 
}
