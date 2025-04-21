using UnityEngine;

public class Scorer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameLogicScript gameLogicScript;

    void Start()
    {
        gameLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            gameLogicScript.AddScore(1);
        }
    }
}
