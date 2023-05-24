using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWriter_Easy : MonoBehaviour
{
    public float total_time = 0f;
    private bool escalate1Minute = false;
    private bool escalate2Minute = false;
    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        total_time += Time.deltaTime;
        if(total_time < 10f)
        {
            uiText.text = "Easy";
        }
        else if (total_time >= 10f && !escalate1Minute)
        {
            uiText.text = "Medium";
            escalate1Minute = true;
        }
        else if (total_time >= 20f && !escalate2Minute)
        {
            uiText.text = "Hard";
            escalate2Minute = true;
        }
    }
}
