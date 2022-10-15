using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followSpeed = 4f;
    public float yOffset = -1f;
    private Transform player1, player2;
    
    void Update()
    {
        Vector3 newPosPlayer1 = new Vector3(player1.position.x, player1.position.y + yOffset, -10f); //player x y position
        transform.position = Vector3.Slerp(transform.position, newPosPlayer1, followSpeed * Time.deltaTime);
    }
}
