using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerScript : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    [SerializeField] GameObject plataforma1;
    [SerializeField] GameObject plataforma2;

    private ButtonPressed buttonPressed1;
    private ButtonPressed buttonPressed2;

    private Player colorPlayer1;
    private Player colorPlayer2;

    [SerializeField] GameObject esferaRoja;
    [SerializeField] GameObject esferaAzul;

    private bool onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        buttonPressed1 = plataforma1.GetComponent<ButtonPressed>();
        buttonPressed2 = plataforma2.GetComponent<ButtonPressed>();
        colorPlayer1 = player1.GetComponent<Player>();
        colorPlayer2 = player2.GetComponent<Player>();
        onPlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(onPlatform){
            if(buttonPressed1.pressed && buttonPressed2.pressed){
                Debug.Log("pressing");
                onPlatform = false;
                if(Random.Range(0, 10) % 2 == 0){
                    colorPlayer1.red = true;
                    colorPlayer2.blue = true;
                }
                else{
                    colorPlayer1.blue = true;
                    colorPlayer2.red = true;
                }
                fadeOut();
            }
        }
    }

    private void fadeOut(){
        float opacity = 1.0f;
        // while(opacity != 0.0f){
        //     esferaRoja.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,opacity);
        //     opacity -= 0.01f;
        // }
    }


}
