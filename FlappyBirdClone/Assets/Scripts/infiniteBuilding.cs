using UnityEngine;

public class infiniteBuilding : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Material material;
    float distance;

    [Range(0f, 0.5f)] 
    public float speed=0.2f;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime*speed;
        material.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
