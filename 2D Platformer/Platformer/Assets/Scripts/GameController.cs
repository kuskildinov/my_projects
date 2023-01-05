using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace Platformer_test
{
    
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Text Coins_score_text;
        [SerializeField] private GameObject pause_panel;
        [SerializeField] private GameObject player;
        private bool player_take_coin;
        private int coins_score;

        private void Awake()
        {
            Time.timeScale = 1;
            coins_score = 0;
            PlayerPrefs.SetInt("lvl_index",SceneManager.GetActiveScene().buildIndex);
        }
        private void FixedUpdate()
        {
           coins_score = player.GetComponent<Player_Interactions>().coin_score;
           Coins_score_text.text = coins_score.ToString();
            if (Input.GetKey(KeyCode.Escape))
            {
                pause_panel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void Pause_game()
        {
            Time.timeScale = 0;
        }
        public void Resume_game()
        {
            Time.timeScale = 1;
        }       
    }
}
