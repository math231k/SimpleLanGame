using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void multiplayer()
    {

    }
    public void exitGame()
    {
        Application.Quit();
    }
}