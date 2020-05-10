using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    //[SerializeField] private string nextSceneName;
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    SceneManager.LoadScene(nextSceneName);
    //}
}

