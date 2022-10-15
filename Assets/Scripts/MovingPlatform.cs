using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int cantMovimientoX;
    public int cantMovimientoY;
    public int cont;
    private bool moveRight;
    private bool moveLeft;
    [SerializeField] GameObject target;
    private ButtonPressed buttonPressed;


    private void Awake()
    {
        moveRight = true;
        moveLeft = false;
        buttonPressed = target.GetComponent<ButtonPressed>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cont < cantMovimientoX && moveRight && buttonPressed.pressed)
        {
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
            cont++;
        }
        else
        {
            if (moveLeft == false && buttonPressed.pressed)
            {
                moveLeft = true;
                moveRight = false;
            }
            if (cont > 0 && moveLeft && buttonPressed.pressed)
            {
                transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y);
                cont--;
            }else{
                moveLeft = false;
                moveRight = true;
            }

        }
    }

}
