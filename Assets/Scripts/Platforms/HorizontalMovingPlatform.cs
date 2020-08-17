using UnityEngine;

public class HorizontalMovingPlatform : Platform
{

    private float randomnes;
    private Vector3 startPosition;
    void Awake()
    {
        startPosition = transform.position;
        randomnes = Random.Range(0f, 1f);
    }


    void Update()
    {
        float floatingValue = Mathf.Sin(Time.time + randomnes) * 2;
        transform.position = new Vector3(startPosition.x + floatingValue,startPosition.y,startPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnCollisionPlatformBehaviour(player);
        }
    }

    protected override void OnCollisionPlatformBehaviour(Player player)
    {
        base.OnCollisionPlatformBehaviour(player);
    }

    public override void Reinitialize(Vector3 newPosition)
    {
        startPosition = newPosition;
    }
}
