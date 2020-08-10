using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float movementMultiplayer;

    private float movement;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x,jumpForce,velocity.z);
    }
    void Update()
    {
        movement = Input.GetAxis("Horizontal"); // make touch here
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(movement * movementMultiplayer, velocity.y, velocity.z);
    }
}
