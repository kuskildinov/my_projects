using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class Bat_mob : MonoBehaviour
    {
        private Health hp;

        // Start is called before the first frame update
        void Start()
        {
            hp = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!hp.is_Alive)
            {
                Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}

