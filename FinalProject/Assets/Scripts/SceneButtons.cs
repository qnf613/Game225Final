using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{

    public void loadCredit()
    {
        Application.LoadLevel(1);
    }

    public void loadGame()
    {
        Application.LoadLevel(2);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exit the Game");
    }

    public void backToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

