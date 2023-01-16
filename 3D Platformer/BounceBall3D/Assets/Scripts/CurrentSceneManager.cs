using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ScenesManager sceneManager;
    public Transform startPoint;
    public bool restart = false;

    void Start()
    {
        Time.timeScale = 1;
        player.transform.position = startPoint.position;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
    public void BackToMenu()
    {
        sceneManager.BackToMenuScene();
    }
    public void RestartLevel()
    {       
            sceneManager.RestartLevel();  
    }
 
}
