using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer_test
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float max_HP;
        public float HP;
        public bool is_Alive = true;
        public bool damaged;

        private void Awake()
        {
            HP = max_HP;
            is_Alive = true;
        }
        
        public void Take_damage(float damage)
        {
            damaged = true;         
            HP -= damage;
            Check_is_alive();
        }
        public void Check_is_alive()
        {
            if (HP > 0) is_Alive = true;
            else is_Alive = false;
        }        
    }
}
