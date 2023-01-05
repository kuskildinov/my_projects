using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class Skeleton_controller : MonoBehaviour
    {
        [SerializeField] Transform move_point;
        [SerializeField] private float speed;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(move_point.position.x * speed,rb.velocity.y);
        }
    }

}

