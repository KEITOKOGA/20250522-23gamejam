using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitButton : MonoBehaviour
{

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainTitle");
    }

    public void Retry()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
