using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followSpeed;
    public Transform player1, player2;
    private Vector2 pos, vel;
    
    void Update()
    {
        /*Vector3 newPosPlayer1 = new Vector3(player1.position.x, player1.position.y + yOffset, -10f); //player x y position
        transform.position = Vector3.Slerp(transform.position, newPosPlayer1, followSpeed * Time.deltaTime);
        */
        pos = (player1.position + player2.position) * 0.5f;
        transform.position = Vector2.SmoothDamp(transform.position, pos, ref vel, followSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
