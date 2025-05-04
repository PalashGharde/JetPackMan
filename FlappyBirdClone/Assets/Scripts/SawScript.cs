using System;
using System.Security.Cryptography;
using Unity.Mathematics;
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

    void Start()
    {
        woodenDoor.SetActive(false);
        metalDoor.SetActive(false);
        gameLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
        pipeSpwanerLogic = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<pipeSpwaner>();
        SpawnObstacle();
        UpdateMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnObstacle()
    {
        bool chance = Random.Range(0f, 1f) <= 0.5f;
        int obsNum = pipeSpwanerLogic.GetObstacleNum();
        Debug.Log("obsNum, chance" + obsNum + ", " + chance);
        
        switch (obsNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                if (chance)
                {
                    woodenDoor.SetActive(true);
                    break;
                }
                else
                {
                    metalDoor.SetActive(true);
                    break;
                }
            case 4:
                break;
            case 5:
                if (chance)
                {
                    woodenDoor.SetActive(true);
                }
                break;
            case 6:
                break;
            case 7:
                if (chance)
                {
                    metalDoor.SetActive(true);
                }
                break;
            case 8:
                break;
            case 9:
                if (chance)
                {
                    woodenDoor.SetActive(true);
                }
                else
                {
                    metalDoor.SetActive(true);
                }
                break;
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
                    moveSpeed = 3.3f;
                    break;
                case 2:
                    moveSpeed = 3.6f;
                    break;
                case 3:
                    moveSpeed = 3.9f;
                    break;
                case 4:
                    moveSpeed = 4.2f;
                    break;
                case 5:
                    moveSpeed = 4.5f;
                    break;
                case 6:
                    moveSpeed = 4.8f;
                    break;
                case 7:
                    moveSpeed = 5.1f;
                    break;
                case 8:
                    moveSpeed = 5.4f;
                    break;
                case 9:
                    moveSpeed = 5.7f;
                    break;
                case 10:
                    moveSpeed = 6.0f;
                    break;
            }
        }

    }
}
