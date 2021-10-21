using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    #region singleton
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    #endregion

    public void GameOver()
    {
        ScoreController.Instance.SetHighScore();
        gameOverPanel.SetActive(true);
        Debug.Log("lose");
        Time.timeScale = 0f;
    }
}
