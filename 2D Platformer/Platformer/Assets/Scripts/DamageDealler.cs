using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class DamageDealler : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float coast;
        [SerializeField] private AudioClip fire_sound;

        private AudioSource audio_source;
        private void Start()
        {
            audio_source = GetComponent<AudioSource>();
            audio_source.PlayOneShot(fire_sound);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().Take_damage(damage);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Ground"))
            {
                Destroy(gameObject);

            }
        }

        public void Destroyer()
        {
            Destroy(gameObject);
        }
    }
}
