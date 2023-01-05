using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer_test
{
    public class Next_level : MonoBehaviour
    {
        [SerializeField] Player_Interactions player;     
        [SerializeField] GameObject helper;

        private void FixedUpdate()
        {
            if(Vector2.Distance(transform.position,player.transform.position) <= 0.4f)
            {
                helper.SetActive(true);
                if (Input.GetKey(KeyCode.W))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else helper.SetActive(false);
        }
    }
}

