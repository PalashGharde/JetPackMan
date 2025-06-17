using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Linq;

public class GameLogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore = 0;
    public Text textUI;
    public GameObject remainingLocksUI;
    private int lockRemaining = 3;
    public Text lockRemainingUI;
    public GameObject[] Keys;
    public GameObject gameOverScreen;
    public Minigame minigame;
    public int playerLife = 3;
    private int gamelevel = 0;
    public KeyAnimScript keyAnim;


    [ContextMenu("AddScore")]
    public void AddScore(int score)
    {
        playerScore += score;
        textUI.text = playerScore.ToString();

        if( playerScore % 3 == 0 && gamelevel<=10 )
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

    public void UnlockLockUnsuccessful()
    {
        playerLife -= 1;
        Debug.Log("Life Lost" + playerLife);
        Keylost();
        if (playerLife == 0)
        {
            minigame.EndMinigameLost();
        }
    }

    public void Keylost()
    {
        switch (playerLife)
        {
            case 0:
                Keys[1].SetActive(false);
                break;
            case 1:
                Keys[1].SetActive(false);
                break;
            case 2:
                Keys[2].SetActive(false);
                break;
        }
    }

    public void UnlockLockSuccessful()
    {
        lockRemaining -= 1;
        Debug.Log("unlocking" + lockRemaining.ToString());
        lockRemainingUI.text = lockRemaining.ToString();
        minigame.ChangePinLocation();
        if (lockRemaining == 0)
        {
            minigame.EndMinigameWin();
        }
    }

    public void StartMinigame()
    {
        lockRemaining = 3;
        playerLife = 3;
        lockRemainingUI.text = lockRemaining.ToString();
        remainingLocksUI.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            Keys[i].SetActive(true);
        }
    }

    public void ResetLock()
    {
        remainingLocksUI.SetActive(false);
    }





}
