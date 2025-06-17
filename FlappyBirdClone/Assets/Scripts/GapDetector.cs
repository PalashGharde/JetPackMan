using UnityEngine;

public class GapDetector : MonoBehaviour
{
    private bool colliding = true;
    public GameLogicScript gameLogicScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!colliding){
                gameLogicScript.UnlockLockSuccessful();
            }
            else
            {
                gameLogicScript.UnlockLockUnsuccessful();
            }
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }
}
