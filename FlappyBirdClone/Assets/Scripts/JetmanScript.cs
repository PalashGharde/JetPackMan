using System;
using System.Collections;
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
    public GameObject bloodParticle;
    public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject hackingBullet;
    private bool minigameStarted = false;
    public GameObject flyingFloor;
    private float currentBoostStrength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBoostStrength = boostStrength;
        bloodParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isJetmanAlive && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            jetmanAnimator.SetBool("IsShooting", true);
            StartCoroutine(ShootBullet("Wood"));
            
        }
        if (isJetmanAlive && Input.GetKeyDown(KeyCode.C))
        {
            jetmanAnimator.SetBool("IsShooting", true);
            StartCoroutine(ShootBullet("Hack"));
        }
        //else
        //{
        //    ;
        //}
        if (!minigameStarted) { 
            if (isJetmanAlive && Input.GetKey(KeyCode.Space))  
            {
                jetmanAnimator.SetBool("isBoosting", true);

                // Charge up boost while holding
                currentBoostStrength += boostChargeRate * Time.deltaTime;
                currentBoostStrength = Mathf.Clamp(currentBoostStrength, boostStrength, maxBoostStrength);


                myRigidBody.linearVelocity = Vector2.up * currentBoostStrength;
            }
            else
            {
                jetmanAnimator.SetBool("isBoosting", false);
                currentBoostStrength = boostStrength;
            }
        }
        else
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{


            //    //if (gameLogic.UnlockLock () == 0)
            //    //{
            //    //    gameLogic.ResetLock();
            //    //    StopMinigame();
            //    //}
                
            //}
            myRigidBody.linearVelocity = Vector2.up * 5f;
        }
    }


    public IEnumerator ShootBullet(string BulletType)
    {
        if(BulletType == "Wood")
        {
            Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation);
        }
        else if (BulletType == "Hack")
        {
            Instantiate(hackingBullet, bulletSpawner.transform.position, hackingBullet.transform.rotation);
        }

        yield return new WaitForSeconds(0.5f);
        jetmanAnimator.SetBool("IsShooting", false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) 
        {
            jetmanAnimator.SetBool("Died", true);
            bloodParticle.SetActive(true);
            isJetmanAlive = false;
            gameLogic.GameOver();
        }
    }

    public void StartMinigame()
    {
        minigameStarted = true;
        flyingFloor.SetActive(true);
        gameLogic.StartMinigame();
        jetmanAnimator.SetBool("isBoosting", true);
    }


    public void StopMinigame()
    {
        minigameStarted = false;
        flyingFloor.SetActive(false);
        gameLogic.ResetLock();
        jetmanAnimator.SetBool("isBoosting", false);
    }

    public bool IsMinigameEnded()
    {
        return !minigameStarted;
    }

}
