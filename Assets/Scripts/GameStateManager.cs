public delegate void GameStateChangeDelegate(GameState gameState);
public class GameStateManager
{

    public static GameStateChangeDelegate OnGameStateChange;

    private static GameState currentState;
    public static GameState CurrentState
    {
        get => currentState;

        set
        {
            if (currentState == value) return;

            currentState = value;
            OnGameStateChange?.Invoke(currentState);

        }
    }
}
public enum GameState
{
    Game,
    Lose,
    Win,
}

