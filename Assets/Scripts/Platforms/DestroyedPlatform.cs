using UnityEngine;

public class DestroyedPlatform : Platform
{
    [SerializeField] private Rigidbody rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            base.OnCollisionPlatformBehaviour(player);
            rigidbody.constraints = ~RigidbodyConstraints.FreezeAll;
        }
    }

    public override void Reinitialize(Vector3 newPosition)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        transform.rotation = Quaternion.identity;
    }

    protected override void OnCollisionPlatformBehaviour(Player player)
    {
        player.GiveForce(jumpForce);
    }

}
