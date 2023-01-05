using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float fireForce;
        [SerializeField] private Transform firePont;
        [SerializeField] private float max_bullet_time;

        private float bullet_time;
        private SpriteRenderer player;

        private void Start()
        {
            bullet_time = 0;
            player = GetComponent<Player_movment>().sprite_renderer;
        }
        public void Shoot(float direction)
        {
            GameObject newBullet = Instantiate(bullet, firePont.position, Quaternion.identity);
            Rigidbody2D newBulletVelocity = newBullet.GetComponent<Rigidbody2D>();
            
            if(!player.flipX)
            {
                newBulletVelocity.velocity = new Vector2(fireForce * 1, newBulletVelocity.velocity.y);
            }
            if (player.flipX)
            {
                newBulletVelocity.velocity = new Vector2(fireForce * -1, newBulletVelocity.velocity.y);
            }

        }
    }
}
