using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree_Hard : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject bombPrefab;
    public GameObject applePrefab;
    public GameObject coinPrefab;
    public float speed = 45f; //I am speed!
    public float leftAndRightEdge = 24f;
    public float appleDropDelay = 0.75f;
    public float bombDropDelay = 1f; // add a delay for dropping bombs
    public float coinDropDelay = 2f;
    public float Appletimer = 0f;
    private float Bombtimer = 0f;
    private float Cointimer = 0f;// add a timer variable
    public float changeDirChance = 0.001f;
    public float total_time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Appletimer += Time.deltaTime;
        if (Appletimer >= appleDropDelay)
        {
            if (Random.value < 0.5f) // adjust the probability of dropping bombs
            {
                Instantiate(applePrefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            }
            Appletimer = 0f; // reset the bomb timer
        }
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        Bombtimer += Time.deltaTime;
        Cointimer += Time.deltaTime;
        total_time += Time.deltaTime; // Update the total time
        if (Bombtimer >= bombDropDelay)
        {
            if (Random.value < 0.85f) // adjust the probability of dropping bombs
            {
                Instantiate(bombPrefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            }
            Bombtimer = 0f; // reset the bomb timer
        }

        if (Cointimer >= coinDropDelay)
        {
            if (Random.value < 1f) // adjust the probability of dropping coins
            {
                Instantiate(coinPrefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            }
            Cointimer = 0f; // reset the coin timer
        }
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (Random.value < changeDirChance)
        {
            speed = speed * -1;
        }
    }
}