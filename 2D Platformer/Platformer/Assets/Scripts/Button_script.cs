using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer_test
{
    public class Button_script : MonoBehaviour
    {
        [SerializeField] AudioClip click_sound;
        [SerializeField] AudioClip hover_sound;
        private AudioSource audio;

        private void Awake()
        {
            audio = GetComponent<AudioSource>();
        }

        public void Click()
        {
            audio.PlayOneShot(click_sound);
        }
        public void Hover()
        {
            audio.PlayOneShot(hover_sound); 
        }


    }
}


