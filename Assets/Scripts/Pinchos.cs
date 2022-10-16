using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    private Player jugador1;
    private Player jugador2;

    // Start is called before the first frame update
    void Start()
    {   
        jugador1 = Player1.GetComponent<Player>();
        jugador2 = Player2.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            Player1.transform.position = new Vector2(jugador1.posXCP, jugador1.posYCP);
            Player2.transform.position = new Vector2(jugador2.posXCP, jugador2.posYCP);
        }
    }
}
