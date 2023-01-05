using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private Coin coinPrefab;
        [SerializeField] private Player_movment player;
        [SerializeField] private int how_many_coins;
        [SerializeField] private float coin_jump_force;
        [Header("Audio")]
        [SerializeField] private AudioClip open_sound;
        private AudioSource audio_source;
        

        private bool open;
        private bool player_close;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            audio_source = GetComponent<AudioSource>();
            open = false;
        }
        private void FixedUpdate()
        {
            Player_close();
            if(open && player_close)
            {
                anim.SetBool("open",true);
            }
        }
        private void Open()
        {
            Coin[] newCoins = new Coin[how_many_coins];
            for (int i = 0; i < newCoins.Length; i++)
            {
                newCoins[i] = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coinShoot(newCoins[i]);
            }
            audio_source.PlayOneShot(open_sound);

        }

        private void coinShoot(Coin coin)
        {
            Vector2 jump_dir = new Vector2(Random.Range(-1, 2), 1);
            coin.GetComponent<Rigidbody2D>().AddForce(jump_dir * coin_jump_force, ForceMode2D.Impulse);
        }

        private void Player_close()
        {
            if(Vector2.Distance(transform.position,player.transform.position) <= 0.3f)
            {
                player_close = true;
                if(Input.GetKey(KeyCode.E))
                {
                    open = true;
                }
            }
        }
    }
}
