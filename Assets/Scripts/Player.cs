using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float movementMultiplayer;

    private float movement;


    public void GiveForce(float jumpForce)
    {
        animator.SetTrigger("collided");
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x,jumpForce,velocity.z);


        //PlayerPrefs.SetInt("NameOfFile", currentScore);
        //currentScore = PlayerPrefs.GetInt("NameOfFile");
    }




    Vector3 startPosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            movement += - (startPosition - Input.mousePosition).x * Time.deltaTime;

            movement = Mathf.Clamp(movement, -1, 1);

        
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            movement = 0;
        }
        movement = Mathf.Lerp(movement, 0, Time.deltaTime);

       // movement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(movement * movementMultiplayer, velocity.y, velocity.z);
    }
}
