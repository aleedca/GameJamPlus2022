using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    private float Horizontal;
    private float Vertical;
    private Rigidbody2D ridigbody2D;
    private SpriteRenderer spriteRenderer;
    private bool Grounded;
    public bool playerOne;
    
    float movementDirection;
    float movementDirectionY;

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
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if(playerOne){
            if(Input.GetKey(KeyCode.A)){
                if(Horizontal < 0.0f) spriteRenderer.flipX = true;
                movementDirection = -1.0f;
                
            }
            else if (Input.GetKey(KeyCode.D)){
                if (Horizontal > 0.0f) spriteRenderer.flipX = false;
                movementDirection = 1.0f;
            }
            else{
                movementDirection = 0.0f;
            }
            if (Input.GetKey(KeyCode.W)){
                movementDirectionY = 1.0f;
            }
            else if (Input.GetKey(KeyCode.S)){
                movementDirectionY = -1.0f;
            }
            else{
                movementDirectionY = 0.0f;
            }
        }
        else{
            if(Input.GetKey(KeyCode.LeftArrow)){
                if(Horizontal < 0.0f) spriteRenderer.flipX = true;
                movementDirection = -1.0f;
                
            }
            else if (Input.GetKey(KeyCode.RightArrow)){
                if (Horizontal > 0.0f) spriteRenderer.flipX = false;
                movementDirection = 1.0f;
            }
            else{
                movementDirection = 0.0f;
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                movementDirectionY = 1.0f;
            }
            else if (Input.GetKey(KeyCode.DownArrow)){
                movementDirectionY = -1.0f;
            }
            else{
                movementDirectionY = 0.0f;
            }
        }

    }

    private void FixedUpdate(){
        
        ridigbody2D.velocity = new Vector2(movementDirection*Speed, movementDirectionY*Speed);
        

    } 
}
