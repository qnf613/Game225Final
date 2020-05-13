using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    [SerializeField] private string CurrentScene;

    public void loadCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Tutorial");
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

    public void reStart()
    {
        SceneManager.LoadScene(CurrentScene);
    }

}

