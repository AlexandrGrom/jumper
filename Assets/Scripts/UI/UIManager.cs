using UnityEngine;

public class UIManager : MonoBehaviour
{
    static private bool isPause;


    [SerializeField] private GameObject GameScreen;
    [SerializeField] private GameObject LoseScreen;

    void Awake()
    {
        GameScreen.SetActive(true);
        GameStateManager.OnGameStateChange += OnGameStateChange;
    }

    private void OnGameStateChange(GameState state)
    {
        if (state == GameState.Lose)
        {
            OnLose();
        }
    }

    private void OnLose()
    {
        GameScreen.SetActive(false);
        LoseScreen.SetActive(true);

    }

    public void SetTimescale()
    {
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;
    }

    
}
