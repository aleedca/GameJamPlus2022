using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] GameObject buttonDoor;
    private ButtonPressed buttonPressed;
    public int cantMovement;
    private int cont;



    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = buttonDoor.GetComponent<ButtonPressed>();
        cont = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (cont < cantMovement && buttonPressed.pressed){
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            cont++;
        }
        
    }
}
