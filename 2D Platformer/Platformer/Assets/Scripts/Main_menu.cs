using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public Text game_version;
    private int last_lvl_index;

    private void Start()
    {
        last_lvl_index = PlayerPrefs.GetInt("lvl_index");
        PlayerPrefs.SetInt("coin_score", 0);        
        game_version.text = "v." + Application.version;
        AudioListener.volume = 1;
    }
    public void Start_game()
    {
        SceneManager.LoadScene(last_lvl_index);
    }
    public void Start_new_game()
    {
        SceneManager.LoadScene(1);
    }
    public void Back_to_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit_game()
    {
        Application.Quit();
    }
    #region levels
    public void Level_1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level_2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level_3()
    {
        SceneManager.LoadScene(3);
    }
    public void Level_4()
    {
        SceneManager.LoadScene(4);
    }
    public void Level_5()
    {
        SceneManager.LoadScene(5);
    }
    #endregion

}
