using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    public void LoadGameLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadStartLevel()
    {
        SceneManager.LoadScene("StartScene");
    }
}
