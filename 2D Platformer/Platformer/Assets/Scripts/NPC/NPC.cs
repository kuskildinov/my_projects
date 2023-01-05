using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class NPC : MonoBehaviour
    {
        [Header("Movment_vars")]
        [SerializeField] private Transform mob_point;
        [SerializeField] private Transform playerPosition;
        [SerializeField] private float speed;
        [Header("Coins")]
        [SerializeField] private Coin coinPrefab;
        [SerializeField] private int how_many_coins;
        [SerializeField] private float coin_jump_force;
        [Header("Audio")]
        [SerializeField] private AudioClip take_damage_sound;

        private AudioSource audio_source;
        private bool give_coins;
        private Animator anim;
        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Vector2 target_to_move;
        private Health hp;

        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            hp = GetComponent<Health>();
            audio_source = GetComponent<AudioSource>();
            target_to_move = mob_point.position;
            give_coins = false;
        }

        private void FixedUpdate()
        {
            if(hp.is_Alive)
            {
                Look_at_player();
                Aggred();
            }      
            if(!hp.is_Alive)
            {
                Death();
            }
        }

        /// <summary>
        /// Игрок заагрил моба
        /// </summary>
        private void Aggred()
        {
            if (Vector2.Distance(transform.position, playerPosition.position) <= 1)
            {
                anim.SetBool("is_run", true);
                target_to_move = playerPosition.position;

            }
            else
            {   target_to_move = mob_point.position;
                anim.SetBool("is_run", false);
            }
            Run_to_player();
            
        }

        /// <summary>
        /// Бежать на игрока
        /// </summary>
        private void Run_to_player()
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, target_to_move, speed * Time.deltaTime);
        }

        /// <summary>
        /// Поворачивается в сторону игрока
        /// </summary>
        private void Look_at_player()
        {
            if(transform.position.x > playerPosition.transform.position.x)
            {
                sr.flipX = true;
            }
            if (transform.position.x < playerPosition.position.x)
            {
                sr.flipX = false;
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "bullet")
            {
                hp.Take_damage(1);
                anim.SetTrigger("take_damage");
                audio_source.PlayOneShot(take_damage_sound);
            }
        }
        private void Coins_after_death()
        {
            Coin[] newCoins = new Coin[how_many_coins];
            for (int i = 0; i < newCoins.Length; i++)
            {
                newCoins[i] = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coinShoot(newCoins[i]);
            }
        }
        private void coinShoot(Coin coin)
        {
            Vector2 jump_dir = new Vector2(Random.Range(-1, 2), 1);
            coin.GetComponent<Rigidbody2D>().AddForce(jump_dir * coin_jump_force, ForceMode2D.Impulse);
        }
        private void Death()
        {            
            if(!give_coins)
            {
                Coins_after_death();
                give_coins = true;
            }
            anim.SetTrigger("death");
        }
    }
}
