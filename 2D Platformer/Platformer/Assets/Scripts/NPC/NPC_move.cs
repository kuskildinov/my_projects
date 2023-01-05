using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer_test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NPC_move : MonoBehaviour
    {
        [SerializeField] private Transform move_point_1;
        [SerializeField] private Transform move_point_2;
        [SerializeField] private float speed;
        

        private Vector2 target_point;
        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Animator anim;
        private Health HP;
        

        private void Awake()
        {
            target_point = move_point_1.position;
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            HP = GetComponent<Health>();
            anim = GetComponent<Animator>();
            
            sr.flipX = true;
        }

        private void FixedUpdate()
        {
            if (HP.is_Alive)
            {
                Move();
            }
            if(!HP.is_Alive)
            {
                Death();
            }
            if(HP.damaged)
            {
                anim.SetTrigger("hit");
                HP.damaged = false;
            }
        }
        private void Move()
        {
            if (transform.position.x <= move_point_1.position.x)
            {
                target_point = move_point_2.position;
                sr.flipX = false;
            }
            else if (transform.position.x >= move_point_2.position.x)
            {
                target_point = move_point_1.position;
                sr.flipX = true;
            }
            //rb.velocity = new Vector2(target_point.x, rb.velocity.y);
            transform.position = Vector2.MoveTowards(transform.position, target_point, speed * Time.deltaTime);
        }

        private void Death()
        {
            anim.SetBool("death", true);
        }
    }
}