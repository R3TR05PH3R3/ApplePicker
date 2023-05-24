using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject basketPrefab;
    public static float bottomY = -20f;
    public float minPosition = -24f; // Minimum position value
    public float maxPosition = 24f; // Maximum position value

    public void CoinMiss()
    {
        GameObject[] coinArray = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject tempGo in coinArray)
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

