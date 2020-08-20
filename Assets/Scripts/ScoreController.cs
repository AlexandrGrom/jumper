using TMPro;
using UnityEngine;

public delegate void OnScoreUpdate(int amount);
public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;

    private int bestScore;

    public static int CurrentScore { get; private set; }


    public static OnScoreUpdate onScoreUpdate;
    
    void Awake()
    {
        CurrentScore = 0;
        onScoreUpdate += UpdateUI;

        bestScore = PlayerPrefs.GetInt(SaveKeys.BestScore);
        bestScoreText.text = bestScore.ToString();
    }

    private void UpdateUI(int amount)
    {
        CurrentScore += amount;
        if (CurrentScore > bestScore)
            PlayerPrefs.SetInt(SaveKeys.BestScore, CurrentScore);
        
        currentScoreText.text = CurrentScore.ToString();
    }


    void OnDestroy()
    {
        onScoreUpdate -= UpdateUI;
    }
}
