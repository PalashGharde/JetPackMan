using UnityEngine;

public class SawScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed;
    public float deadZone = -5;
    public GameLogicScript gameLogicScript;


    void Start()
    {
        gameLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
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
