using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject basketPrefab;
    public static float bottomY = -20f;
    public float minPosition = -24f; // Minimum position value
    public float maxPosition = 24f; // Maximum position value

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGo in appleArray)
        {
            Destroy(tempGo);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
        }
        if (transform.position.x < minPosition || transform.position.x > maxPosition)
        {
            // Reverse the object's horizontal direction
            Vector3 newDirection = new Vector3(-1f * Mathf.Sign(transform.position.x), 0f, 0f);
            GetComponent<Rigidbody>().velocity = newDirection * GetComponent<Rigidbody>().velocity.magnitude;
        }
    }
}
