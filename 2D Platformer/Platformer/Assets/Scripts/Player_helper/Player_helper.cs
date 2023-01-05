using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Platformer_test
{
    public class Player_helper : MonoBehaviour
    {
        [SerializeField] private GameObject help_txt;
        [SerializeField] Transform player_pos;

        private void FixedUpdate()
        {

            if (Vector2.Distance(transform.position,player_pos.position) <= 0.5f)
            {
                help_txt.SetActive(true);
            }
            else
                help_txt.SetActive(false);
        }
           
    }
}
