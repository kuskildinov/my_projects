using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Button[] levels;
    
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if(levels[i])
            {
                SceneManager.LoadScene(i+1);
            }
        }
    }

    public void BackToMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
