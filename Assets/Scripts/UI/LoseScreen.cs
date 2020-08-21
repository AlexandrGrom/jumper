using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : ScreenBase
{
    [Header ("Panel")]
    [SerializeField] private Image panel;
    [SerializeField] private AnimationCurve panelEase;

    [Header ("Game Over")]
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private AnimationCurve gameOverEase;
    
    [Header ("Score Panels")]
    [SerializeField] private Image bestScore;
    [SerializeField] private Image youScore;
    [SerializeField] private TextMeshProUGUI youScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private AnimationCurve scoreEase;


    
    void OnEnable()
    {
        ResetAll();
        StartCoroutine(LoseScreenAnimation());
    }

    private void ResetAll()
    {
        youScoreText.text = "0";
        bestScoreText.text = "0";
        panel.transform.localScale = Vector3.zero;
        bestScore.transform.localScale = Vector3.zero;
        youScore.transform.localScale = Vector3.zero;
        gameOverText.transform.localScale = new Vector3(0,1,1);
    }

    public void RestartGame()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoseScreenAnimation()
    {
        for (float i = 0; i <= 1; i += 0.05f)
        {
            panel.transform.localScale = Vector3.one * panelEase.Evaluate(i); 
            yield return null;
        }

        for (float i = 0; i <= 1; i += 0.05f)
        {
            gameOverText.transform.localScale = new Vector3(1 * gameOverEase.Evaluate(i), 1, 1);
            yield return null;
        }

        for (float i = 0; i <= 1; i += 0.05f)
        {
            youScore.transform.localScale = Vector3.one * scoreEase.Evaluate(i);
            bestScore.transform.localScale = Vector3.one * scoreEase.Evaluate(i);
            yield return null;
        }

        int best = PlayerPrefs.GetInt(SaveKeys.BestScore);
        for (float i = 0; i <= 1; i += 0.05f)
        {
            bestScoreText.text = Mathf.RoundToInt(best * i).ToString();
            yield return null;
        }
        bestScoreText.text = best.ToString();

        int earnedScore = ScoreController.CurrentScore;
        for (float i = 0; i <= 1; i += 0.05f)
        {
            youScoreText.text = Mathf.RoundToInt(earnedScore * i).ToString();
            yield return null;
        }
        youScoreText.text = earnedScore.ToString();



    }

}
