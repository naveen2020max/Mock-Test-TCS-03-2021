using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void TestSwipe()
    {
        SceneManager.LoadScene("Test1");

    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
