using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private Transform player;


    void LateUpdate()
    {
        if (GameStateManager.CurrentState == GameState.Lose) return;

        if (player.position.y < transform.position.y - 9f) GameStateManager.CurrentState = GameState.Lose;
                
        if (player.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y, player.position.z - 10);
            transform.position = newPosition;
        }
    }
}
