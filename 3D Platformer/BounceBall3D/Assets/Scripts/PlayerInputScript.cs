using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceBallInput
{  
    public class PlayerInputScript : MonoBehaviour
    {
        public Vector3 movement;
        public bool jump;
        void FixedUpdate()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXES);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXES);

            jump = Input.GetButton(GlobalStringVars.JUMP_AXES);
            movement = new Vector3(horizontal, 0, vertical);
        }
    }
}
