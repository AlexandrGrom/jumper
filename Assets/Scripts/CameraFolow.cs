using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private Transform player;


    void LateUpdate()
    {
        if (player.position.y > transform.position.y)
        {
            //Vector3 newPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y, player.position.z - 10);
            transform.position = newPosition;
        }
    }
}
