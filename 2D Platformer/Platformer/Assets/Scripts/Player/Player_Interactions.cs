using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer_test
{
    /// <summary>
    /// Взаимодействия игрока
    /// </summary>
    public class Player_Interactions : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private GameObject game_over_panel;
        [Header("Audio")]
        [SerializeField] private AudioClip coin_sound;

        private AudioSource audio_source;
        private Health HP;
        private Animator anim;
        private Hp_bar hp_bar;
        
       
        public bool can_take_damage;
        public bool take_damage;        
        public int coin_score;


        private void Awake()
        {
            HP = GetComponent<Health>();
            hp_bar = GetComponentInChildren<Hp_bar >();
            anim = GetComponent<Animator>();
            audio_source = GetComponent<AudioSource>();
            can_take_damage = true;
            coin_score = PlayerPrefs.GetInt("coin_score");
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayerPrefs.SetInt("coin_score", 0);
            }
        }

        private void FixedUpdate()
        {
            if (take_damage && can_take_damage)
            {
                HP.Take_damage(damage);
                anim.SetTrigger("PlayerTakeDamage");
                Debug.Log("УРОН!");
                can_take_damage = false;
                if (!HP.is_Alive)
                {
                    Death();
                }
            }           
        }

        /// <summary>
        /// Получил урон
        /// </summary>
       private void Damaged()
       {
            hp_bar.img.fillAmount -= 0.2f;
       }

        /// <summary>
        /// Позволяет персонажу получать урон
        /// </summary>
        private void Can_take_damage()
        {
            can_take_damage = true;
        }

        /// <summary>
        /// Смерть
        /// </summary>
        private void Death()
        {
                anim.SetBool("PlayerDeath", true);
                game_over_panel.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
           if(collision.gameObject.tag == "key")
           {
                gameObject.GetComponent<Player_Inventory>().has_key = true;
                collision.gameObject.SetActive(false);
           }
            if (collision.gameObject.tag == "dead_zone")
            {
                Death();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
           
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
           
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                take_damage = false;
            }
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {                
                take_damage = true;
            }

            if (collision.gameObject.tag == "coin")
            {
                coin_score++;
                audio_source.PlayOneShot(coin_sound);
                PlayerPrefs.SetInt("coin_score", coin_score);
                Destroy(collision.gameObject);
            }
            
        }

        private void Stop_time()
        {
            Time.timeScale = 0;
        }

        private void Start_time()
        {
            Time.timeScale = 1;
        }
    }
}
