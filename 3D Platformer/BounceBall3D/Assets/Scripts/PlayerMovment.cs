using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BounceBallInput
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInputScript))]

    public class PlayerMovment : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2.0f;
        [SerializeField] private ParticleSystem jumpParticles;
        [SerializeField] private ParticleSystem deadParticle;

        private float jumpForce = 5.0f;
        private Rigidbody playerRb;
        private Vector3 movement;
        private Vector3 jumpVector = new Vector3(0,1,0);
        private bool jump;      
        private PlayerInputScript inputs;
        private Animator anim;
        
        private void Awake()
        {
            Time.timeScale = 1;
            playerRb = GetComponent<Rigidbody>();
            inputs = GetComponent<PlayerInputScript>();
            anim = GetComponentInParent<Animator>();           
            
        }
        void FixedUpdate()
        {
            jumpParticles.transform.position = transform.position;
            deadParticle.transform.position = transform.position;
            movement = inputs.movement;
            jump = inputs.jump;
            MoveCharacter(movement);
            if(jump && gameObject.GetComponent<PlayerInteractions>().characterOnFloor)
            {
                JumpCharacter();
                gameObject.GetComponent<PlayerInteractions>().characterOnFloor = false;
                
            }
           
        }

        /// <summary>
        /// Передвижение игрока в опредененном направлении
        /// </summary>
        /// <param name="movement"></param>
        void MoveCharacter(Vector3 movement)
        {
            playerRb.AddForce(movement.normalized * speed);            
        }

        /// <summary>
        /// Прыжок игрока
        /// </summary>
        void JumpCharacter()
        {
            playerRb.AddForce(jumpVector.normalized * jumpForce, ForceMode.Impulse);
            anim.SetBool("jump", true);
            jumpParticles.Play();
        }           
       

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
     public void ResetValues()
        {
            speed = 2.0f;
        }
#endif
    }
}
