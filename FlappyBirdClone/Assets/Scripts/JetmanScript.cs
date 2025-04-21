using UnityEngine;

public class JetmanScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float boostStrength;        // Base boost
    public float maxBoostStrength;     // Max boost cap
    public float boostChargeRate;
    public Animator jetmanAnimator;
    public GameLogicScript gameLogic;
    public bool isJetmanAlive = true;

    private float currentBoostStrength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBoostStrength = boostStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if (isJetmanAlive && Input.GetKey(KeyCode.Space))  
        {
            jetmanAnimator.SetBool("isRunning", true);

            // Charge up boost while holding
            currentBoostStrength += boostChargeRate * Time.deltaTime;
            currentBoostStrength = Mathf.Clamp(currentBoostStrength, boostStrength, maxBoostStrength);


            myRigidBody.linearVelocity = Vector2.up * currentBoostStrength;
        }
        else
        {
            jetmanAnimator.SetBool("isRunning", false);
            currentBoostStrength = boostStrength;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) 
        { 
            isJetmanAlive = false;
            gameLogic.GameOver();
        }
    }
}
