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
            StartCoroutine(ShootBullet());
            
        }
        //else
        //{
        //    ;
        //}

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


    public IEnumerator ShootBullet()
    {
        Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation);
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
}
