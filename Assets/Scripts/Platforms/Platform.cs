using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private Collider colision;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected int amoun;

    protected bool isAction = true;

    void Awake()
    {
        OnStartGame();
    }

    protected virtual void OnStartGame()
    {
        GameStateManager.OnGameStateChange += OnGamestateChange;
    }

    void OnGamestateChange(GameState state)
    {
        if (state == GameState.Game) isAction = true;
        else isAction = false;
    }
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

    void OnDestroy()
    {
        GameStateManager.OnGameStateChange -= OnGamestateChange;
    }
}
