using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float movementMultiplayer;

    [SerializeField] private ParticleSystem collisionParticle;

    private float movement;

    void Awake()
    {
        GameStateManager.OnGameStateChange += OnameStateChange;
    }
    public void GiveForce(float jumpForce)
    {
        animator.SetTrigger("collided");
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x,jumpForce,velocity.z);
        collisionParticle.transform.position = transform.position + Vector3.down * 0.5f;
        collisionParticle.Play();
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

    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(movement * movementMultiplayer, velocity.y, velocity.z);
    }

    private void OnameStateChange(GameState state)
    {
        if (state == GameState.Lose)
        {
            OnLose();
        }
    }

    private void OnLose()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }

    void OnDestroy()
    {
        GameStateManager.OnGameStateChange -= OnameStateChange;
    }
}
