using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyChooser : MonoBehaviour
{
    public void PlayGameEasy()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayGameMedium()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayGameHard()
    {
        SceneManager.LoadScene(4);
    }
}
