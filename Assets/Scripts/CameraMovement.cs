using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public List<Transform> targets;
    public Vector3 offset;

    private GameObject player1;
    private GameObject player2; 

    private Player horizontalPlayer1;
    private Player horizontalPlayer2;

    private void Start() {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        horizontalPlayer1 = player1.GetComponent<Player>();
        horizontalPlayer2 = player2.GetComponent<Player>();
    }
    
    private void LateUpdate() {
        if(targets.Count == 0) return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = newPosition;

        float player1X = player1.transform.position.x;
        float player2X = player2.transform.position.x;

        player1X += horizontalPlayer1.movementDirection;
        player2X += horizontalPlayer2.movementDirection;

        float resta = Mathf.Abs(player1X - player2X);

        Debug.Log(resta);

        if(resta >= 16)
        {
            horizontalPlayer1.blocked = true;
            horizontalPlayer2.blocked = true;
            if(player1.transform.position.x > player2.transform.position.x){
                horizontalPlayer1.rightBlock = true;
                horizontalPlayer2.leftBlock = true;
            }
            else{
                horizontalPlayer2.rightBlock = true;
                horizontalPlayer1.leftBlock = true;
            }
        }

        
    }

    Vector3 GetCenterPoint(){
        if(targets.Count == 1) return targets[0].position;

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++){
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
