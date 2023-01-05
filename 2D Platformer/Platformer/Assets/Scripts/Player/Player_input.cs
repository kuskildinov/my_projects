using UnityEngine;
using UnityEngine.UI;

namespace Platformer_test
{
    [RequireComponent(typeof(Player_movment))]
    [RequireComponent(typeof(Shooter))]
    public class Player_input : MonoBehaviour
    {
        private Player_movment player_movment;
        private Shooter shooter;
        public float horizontalDirection;
        public bool is_Jump_button_pressed;
        public float speed;

        private void Awake()
        {
            player_movment = GetComponent<Player_movment>();
            shooter = GetComponent<Shooter>();
        }

        private void Update()
        {
            Movment_PC();           
        }

        #region Управление через ПК

        private void Movment_PC()
        {
            horizontalDirection = Input.GetAxis(Global_String_Vars.HORIZONTAL_AXIS);
            is_Jump_button_pressed = Input.GetButtonDown(Global_String_Vars.JUMP);

            player_movment.Move(horizontalDirection, is_Jump_button_pressed);

            if (Input.GetButtonDown(Global_String_Vars.FIRE_1))
            {
                shooter.Shoot(horizontalDirection);

            }
        }
        #endregion
                
    }

}
