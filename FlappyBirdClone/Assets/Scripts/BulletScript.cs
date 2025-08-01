using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float bulletspeed;
    private Rigidbody2D rb;
    public GameObject sparkParticle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * bulletspeed;
        sparkParticle.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = spark;
            sparkParticle.SetActive(true);
            StartCoroutine(WaitForTime());
            Destroy(gameObject);
        }
    }

    public IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(5);
    }
}
