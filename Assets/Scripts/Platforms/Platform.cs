using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private Collider colision;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected int amoun;
    void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(colision, other.GetComponent<Collider>(),true);
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(colision, other.GetComponent<Collider>(),false);
    }

    protected virtual void OnCollisionPlatformBehaviour(Player player)
    {
        player.GiveForce(jumpForce);
        ScoreController.onScoreUpdate.Invoke(amoun);
    }
    public virtual void Reinitialize(Vector3 newPosition){}
}
