using System;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SawScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed;
    public float deadZone = -5;
    public GameLogicScript gameLogicScript;
    public GameObject woodenDoor;
    public GameObject metalDoor;
    public pipeSpwaner pipeSpwanerLogic;
    public string ObstacleType = "Temp";
    public Minigame minigame;
 

    //private bool minigameStarted = false;

    void Start()
    {
        woodenDoor.SetActive(false);
        metalDoor.SetActive(false);
        ObstacleType = "Temp";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
        pipeSpwanerLogic = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<pipeSpwaner>();
        minigame = GameObject.FindGameObjectWithTag("Minigame").GetComponent<Minigame>();
        SpawnObstacle();
        UpdateMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pipeSpwanerLogic.isMinigameStarted()) { 
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        else
        {
            //int minigameStatus = minigame.IsMinigameEnded();
            
            //if (minigameStatus == 1)
            //{
            //    Debug.Log("minigameStatus                              :" + minigameStatus);
            //    pipeSpwanerLogic.resumeSpawning();
            //    Destroy(gameObject);
            //}
            //else if (minigameStatus == 2)
            //{
            //    Debug.Log("minigameStatus                              :" + minigameStatus);
            //    pipeSpwanerLogic.resumeSpawning();
            //}

            switch (minigame.IsMinigameEnded())
            {
                case 1:
                    {
                        Debug.Log("minigameStatus                              : 1");
                        pipeSpwanerLogic.resumeSpawning();
                        Destroy(gameObject);
                        break;
                    }
                case 2: 
                    {
                        Debug.Log("minigameStatus                              : 2");
                        pipeSpwanerLogic.resumeSpawning();
                        break;
                    }
                default:
                    break;
            }
        }


        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnObstacle()
    {
        bool chance = Random.Range(0f, 1f) <= 0.5f;
        int obsNum = pipeSpwanerLogic.GetObstacleNum();
        
        switch (obsNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                if (chance)
                {
                    woodenDoor.SetActive(true);
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    ObstacleType = "Wood";
                }
                break;
            case 3:
                if (chance)
                {
                    metalDoor.SetActive(true);
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    ObstacleType = "Metal";
                }
                break;
            case 4:
                if (chance)
                {
                    woodenDoor.SetActive(true);
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    ObstacleType = "Wood";
                }
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                if (chance)
                {
                    woodenDoor.SetActive(true);
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    ObstacleType = "Wood";
                }
                break;
            case 8:
                break;
            case 9:
                //if (chance)
                {
                    metalDoor.SetActive(true);
                    gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    ObstacleType = "Metal";
                }
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 && ObstacleType == "Wood")
        {
            woodenDoor.SetActive(false);
        }
        else if(collision.gameObject.layer == 8 && ObstacleType == "Metal")
        {
            //minigameStarted = true; 
            //pipeSpwanerLogic.pauseSpawning();
            minigame.StartMinigame(gameObject);
        }    
    }

    void UpdateMoveSpeed()
    {
        int level = gameLogicScript.GetGameLevel();

        if (level <= 10)
        {
            switch (level)
            {
                case 0:
                    moveSpeed = 3.0f;
                    break;
                case 1:
                    moveSpeed = 3.2f;
                    break;
                case 2:
                    moveSpeed = 3.4f;
                    break;
                case 3:
                    moveSpeed = 3.6f;
                    break;
                case 4:
                    moveSpeed = 3.8f;
                    break;
                case 5:
                    moveSpeed = 4.0f;
                    break;
                case 6:
                    moveSpeed = 4.2f;
                    break;
                case 7:
                    moveSpeed = 4.4f;
                    break;
                case 8:
                    moveSpeed = 4.6f;
                    break;
                case 9:
                    moveSpeed = 4.8f;
                    break;
                case 10:
                    moveSpeed = 5.0f;
                    break;
            }
        }

    }
}
