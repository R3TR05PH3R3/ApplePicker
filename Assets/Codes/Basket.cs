using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public float leftAndRightEdge = 24f;
    public ScoreCounter scoreCounterEasy;
    Scene currentScene;
    void Start()
    { // We'll add code to Start() in Code Listing 29.12
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounterEasy = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition; // a

        // The Camera's z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, select the Main Camera
        // in the Hierarchy and set its tag to MainCamera in the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z; // b

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // c

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        if (mousePos3D.x >= -leftAndRightEdge && mousePos3D.x <= leftAndRightEdge)
        {
            pos.x = mousePos3D.x;
        }
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        currentScene = SceneManager.GetActiveScene();
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject; 

        if (collidedWith.CompareTag("Apple"))
        { 
            Destroy(collidedWith);
            scoreCounterEasy.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounterEasy.score);
        }

        if (collidedWith.CompareTag("Bomb"))
        {
            Destroy(collidedWith);
            ApplePicker app = Camera.main.GetComponent<ApplePicker>();
            app.AppleMissed();
        }
        if (collidedWith.CompareTag("Coin"))
        {
            Destroy(collidedWith);
            CoinUI.AddCoins(1);
        }
    }

}

