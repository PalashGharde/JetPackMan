using UnityEngine;

public class pipeSpwaner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject pipe;
    public float timer = 0;
    public float spawnRate = 3.0f;
    public float lowestHeight = -4.39f;
    public float highestHeight = 1;
    public GameLogicScript gameLogicScript;
    private int pipenum;

    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawnRate();

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
            
    }

    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestHeight, highestHeight)), transform.rotation);
        pipenum += 1;
    }

    public int GetObstacleNum()
    {
        return pipenum % 10;
    }

    void UpdateSpawnRate()
    {
        int level = gameLogicScript.GetGameLevel();
        if (level <= 10)
        {
            switch (gameLogicScript.GetGameLevel())
            {
                case 0:
                    spawnRate = 3.0f;
                    break;
                case 1:
                    spawnRate = 2.8f;
                    break;
                case 2:
                    spawnRate = 2.6f;
                    break;
                case 3:
                    spawnRate = 2.4f;
                    break;
                case 4:
                    spawnRate = 2.2f;
                    break;
                case 5:
                    spawnRate = 2.0f;
                    break;
                case 6:
                    spawnRate = 1.9f;
                    break;
                case 7:
                    spawnRate = 1.8f;
                    break;
                case 8:
                    spawnRate = 1.7f;
                    break;
                case 9:
                    spawnRate = 1.6f;
                    break;
                case 10:
                    spawnRate = 1.5f;
                    break;
            }
        }
        
    }
}
