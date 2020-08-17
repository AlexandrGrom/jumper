using TMPro;
using UnityEngine;

public delegate void OnScoreUpdate(int amount);
public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;

    private int bestScore;
    private int currentScore;


    public static OnScoreUpdate onScoreUpdate;
    
    void Awake()
    {
        onScoreUpdate += UpdateUI;

        bestScore = PlayerPrefs.GetInt(SaveKeys.BestScore);
        bestScoreText.text = bestScore.ToString();
    }

    private void UpdateUI(int amount)
    {
        currentScore += amount;
        if (currentScore > bestScore)
            PlayerPrefs.SetInt(SaveKeys.BestScore, currentScore);
        
        currentScoreText.text = currentScore.ToString();
    }


    void OnDestroy()
    {
        onScoreUpdate -= UpdateUI;
    }
}
