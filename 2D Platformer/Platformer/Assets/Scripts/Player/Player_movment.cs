using UnityEngine;
namespace Platformer_test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player_movment : MonoBehaviour
    {
        [Header("Movment vars")]
        [SerializeField] private float Jump_force;
        [SerializeField] private float Speed;
        [SerializeField] private float jumpOffset;

        [Header("Settings")]
        [SerializeField] private Transform ground_colleder_transform;       
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private AnimationCurve curve;

        private bool is_grounded = false;
        private bool can_attack = true;  
        
        private Rigidbody2D rb;           
        private Animator anim;
        public SpriteRenderer sprite_renderer;

        private Health hp;
               
        

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sprite_renderer = GetComponent<SpriteRenderer>();
            hp = GetComponent<Health>();
            
        }

        private void FixedUpdate()
        {
            Speed = GetComponent<Player_input>().speed;
            Vector3 overlapCircleTransform = ground_colleder_transform.position;
            is_grounded = Physics2D.OverlapCircle(overlapCircleTransform, jumpOffset, groundMask);           
        }

        /// <summary>
        /// Передвижения игрока
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="is_jump"></param>
        public void Move(float direction, bool is_jump)
        {
            anim.SetFloat("Run", Mathf.Abs(direction));
            
            //При нажатии кнопки прыжка
            if (is_jump)
            {
                Jump();
                anim.SetBool("PlayerJump", true);
            }
            else anim.SetBool("PlayerJump", false);

            //При нажатии кнопок в сторону
            if (Mathf.Abs(direction) > 0.0001f && hp.is_Alive)
            {
                Run(direction);
            }
            SpriteFlip(direction);
        }

        /// <summary>
        /// Прыжок
        /// </summary>
        private void Jump()
        {
            if (is_grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, Jump_force);
                anim.SetBool("PlayerJump", false);
            }
        }

        /// <summary>
        /// Бег
        /// </summary>
        /// <param name="direction"></param>
        private void Run (float direction)
        {            
                HorizontalMovment(direction);                
        }           
        

        /// <summary>
        /// Движение по горизонтали
        /// </summary>
        /// <param name="direction"></param>
        private void HorizontalMovment(float direction)
        {
             rb.velocity = new Vector2(curve.Evaluate(direction) * Speed ,rb.velocity.y);
        }
               
       
        /// <summary>
        /// Поворот спрайта в зависимости от направления движения
        /// </summary>
        /// <param name="direction"></param>
        private void SpriteFlip(float direction)
        {
            
            if (direction > 0 && can_attack == true)
            {
                sprite_renderer.flipX = false;
            }
            if (direction < 0 && can_attack == true)
            {
                sprite_renderer.flipX = true;
            }
        }

      
    }
} 