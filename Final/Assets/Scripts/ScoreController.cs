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
    private int score = 0;

    public void IncreaseScore(int scoreCount)
    {
        score += scoreCount;
        scoreText.text = "Score : " + score.ToString();
    }
}
