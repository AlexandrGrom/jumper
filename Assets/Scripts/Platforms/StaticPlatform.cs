using UnityEngine;

public class StaticPlatform : Platform
{
    private void OnCollisionEnter(Collision collision)
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
}
