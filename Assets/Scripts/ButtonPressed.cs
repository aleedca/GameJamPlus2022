using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public bool pressed;
    private int speed;
    private int pressAnimated;
    [SerializeField] GameObject buttonSprite; 

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        pressAnimated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(pressed && this.pressAnimated < 4){
            buttonSprite.transform.position = new Vector2(transform.position.x, transform.position.y - 0.15f);
            this.pressAnimated += 1; 
        }else if(pressed == false && this.pressAnimated > 0){
            buttonSprite.transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
            this.pressAnimated -= 1; 
        }    
    }
    


    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            pressed = true;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            pressed = false;
        }
    }
    


}
