using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore = 0;
    public Text textUI;
    public GameObject gameOverScreen;

    private int gamelevel = 0;


    [ContextMenu("AddScore")]
    public void AddScore(int score)
    {
        playerScore += score;
        textUI.text = playerScore.ToString();

        if( playerScore % 2 == 0 && gamelevel<=10 )
        {
            gamelevel += 1;
            //Debug.Log("next Level");
        }
    }

    public int GetGameLevel()
    {
        return gamelevel;
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
