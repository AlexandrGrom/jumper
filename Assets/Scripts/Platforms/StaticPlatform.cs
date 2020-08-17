using UnityEngine;

public class StaticPlatform : Platform
{
    [SerializeField] float jumpForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnCollisionPlatformBehaviour(player);
        }
    }

    protected override void OnCollisionPlatformBehaviour(Player player)
    {
        player.GiveForce(jumpForce);
    }
}
