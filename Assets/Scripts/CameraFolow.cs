using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float lastPosition;


    void Update()
    {
        if (player.position.y < lastPosition)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x, player.position.y + 2, transform.position.z);
        lastPosition = player.position.y;
    }
}
