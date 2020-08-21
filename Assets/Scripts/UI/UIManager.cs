using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{


    [SerializeField] private ScreenBase[] screens;
    private Dictionary<GameState, ScreenBase> screensDictionaty;

    private bool isPause;


    //make dictionary

    void Awake()
    {
        screensDictionaty = screens.ToDictionary(item => item.state, item => item);
        screensDictionaty[GameState.Game].gameObject.SetActive(true);
        isPause = false;
        GameStateManager.OnGameStateChange += OnGameStateChange;
        GameStateManager.CurrentState = GameState.Game;


    }

    private void OnGameStateChange(GameState state)
    {
        foreach (var screen in screensDictionaty) screen.Value.gameObject.SetActive(false);
        screensDictionaty[state].gameObject.SetActive(true);
    }


    public void SetPause()
    {
        isPause = !isPause;
        GameStateManager.CurrentState = isPause ? GameState.Paues : GameState.Game;
    }

    void OnDestroy()
    {
        GameStateManager.OnGameStateChange -= OnGameStateChange;
    }
}
