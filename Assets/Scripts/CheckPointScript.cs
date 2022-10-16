using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    private GameObject player1;
    private GameObject player2;

    private Player script1;
    private Player script2;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        script1 = player1.GetComponent<Player>();
        script2 = player2.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if(other.gameObject == player1 || other.gameObject == player2){
            Debug.Log("entro");
            script1.posXCP = this.transform.position.x;
            script1.posYCP = this.transform.position.y;
            script2.posXCP = this.transform.position.x;
            script2.posYCP = this.transform.position.y;
        }
    }
    
}
