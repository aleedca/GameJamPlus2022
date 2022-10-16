using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractablePlatform : MonoBehaviour
{
    [SerializeField] GameObject buttonPlatform;
    private ButtonPressed buttonPressed;
    public Sprite platformActive;
    public Sprite platformInactive;
    public int cont;
    public int cantidadEspera;
    private bool neverPressed;

    
    private void Start()
    {
        buttonPressed = buttonPlatform.GetComponent<ButtonPressed>();
        neverPressed = true;
        this.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed.pressed){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = platformActive;
            neverPressed = false;
            this.GetComponent<Collider2D>().enabled = true;
        }else if(buttonPressed.pressed == false){
            if(cont < cantidadEspera){
                if(neverPressed == false && buttonPressed.pressed == false){
                    cont++;
                }
            }else{
                this.gameObject.GetComponent<SpriteRenderer>().sprite = platformInactive;
                this.GetComponent<Collider2D>().enabled = false;
                neverPressed = true;
                cont = 0;
            }

        }
    }
}
