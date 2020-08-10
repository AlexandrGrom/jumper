using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x,jumpForce,velocity.z);
    }
    void Update()
    {
        
    }
}
