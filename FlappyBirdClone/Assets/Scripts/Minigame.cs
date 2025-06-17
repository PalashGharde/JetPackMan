using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{

    public GameObject lockMinigame;
    public JetmanScript player;
    private GameObject Rotator;
    private GameObject Pin;
    private int Direction = 1;
    public float RotatorSpeed = 4f;
    public bool MinigameStarted = false;
    public bool MinigameFinishedSuccesfully = false;
    public pipeSpwaner pipeSpwaner;
    private GameObject CurrentSaw;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rotator = lockMinigame.transform.GetChild(1).gameObject;
        Pin = lockMinigame.transform.GetChild(2).gameObject;
        Pin.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0,360));
    }

    // Update is called once per frame
    void Update()
    {
        Rotator.transform.RotateAround( Rotator.transform.position,Vector3.forward , RotatorSpeed * Time.deltaTime * Direction);
    }

    public void StartMinigame(GameObject CurrSaw)
    {
        CurrentSaw = CurrSaw;   
        MinigameStarted = true;
        MinigameFinishedSuccesfully = false;
        Debug.Log("Minigame Started");
        pipeSpwaner.pauseSpawning();
        lockMinigame.SetActive(true);
        player.StartMinigame();
    }

    public int IsMinigameEnded() // change this to int
    {
        if (!MinigameStarted && MinigameFinishedSuccesfully)
        {
            return 1;
        }
        else if (!MinigameStarted && !MinigameFinishedSuccesfully)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

    //public bool isMinigameEndedSuccess()
    //{
    //    return MinigameFinishedSuccesfully;
    //}
    public void ChangePinLocation()
    {
        Pin.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }


    public void EndMinigameWin()
    {
        Destroy(CurrentSaw);
        MinigameStarted = false;
        MinigameFinishedSuccesfully = true;
        Debug.Log("MinigameFinishedSuccesfully    " + MinigameFinishedSuccesfully);
        pipeSpwaner.resumeSpawning();
        lockMinigame.SetActive(false);
        player.StopMinigame();
    }

    public void EndMinigameLost()
    {
        MinigameStarted = false;
        MinigameFinishedSuccesfully = false;
        lockMinigame.SetActive(false);
        player.StopMinigame();
    }




}
