using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject basketPrefab;
    public static float bottomY = -20f;
    public float minPosition = -24f; // Minimum position value
    public float maxPosition = 24f; // Maximum position value

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BombMiss()
    {
        GameObject[] bombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject tempGo in bombArray)
        {
            Destroy(tempGo);
        }
    }
    void Update()
    {

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        }
        if (transform.position.x < minPosition || transform.position.x > maxPosition)
        {
            // Reverse the object's horizontal direction
            Vector3 newDirection = new Vector3(-1f * Mathf.Sign(transform.position.x), 0f, 0f);
            GetComponent<Rigidbody>().velocity = newDirection * GetComponent<Rigidbody>().velocity.magnitude;
        }
    }
}
