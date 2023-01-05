using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer_test
{
    public class Hp_bar : MonoBehaviour
    {
        [SerializeField] Player_Interactions player;
        public Image img;

        private void Awake()
        {
            img = GetComponent<Image>();
        }       
    }
}
