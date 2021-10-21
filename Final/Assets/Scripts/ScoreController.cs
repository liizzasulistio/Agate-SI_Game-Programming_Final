using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region Singleton
    private static ScoreController instance = null;
    public static ScoreController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ScoreController>();
            }
            return instance;
        }
    }
    #endregion

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    private const string HIGHSCORE = "high_score";
    private int score = 0;
    private int highscore = 0;

    private void Start()
    {
        SetHighScore();
    }

    public void IncreaseScore(int scoreCount)
    {
        score += scoreCount;
        scoreText.text = "Score : " + score.ToString();
    }

    public void SetHighScore()
    {
        if (highScoreText == null) return;
        highscore = Mathf.Max(score, PlayerPrefs.GetInt(HIGHSCORE));
        PlayerPrefs.SetInt(HIGHSCORE, highscore);
        highScoreText.text = "High Score : " + highscore.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
