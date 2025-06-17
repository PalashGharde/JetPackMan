using System.Collections;
using UnityEngine;

public class KeyAnimScript : MonoBehaviour
{
    public Animator keyanimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void PlayKeyAnimation()
    {
        keyanimator.SetBool("KeyLost", true);
        StartCoroutine(WaitForTime());
        
    }

    public IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(5);
    }
}
