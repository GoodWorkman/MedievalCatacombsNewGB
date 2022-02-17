using UnityEngine;

namespace Player.Weapons.Bullet
{
    public class PlayerBullet : MonoBehaviour
    {
        public float speed = 2f;
        [SerializeField] private Rigidbody _rigidbody;

        public void Start()
        {
            _rigidbody.velocity = transform.forward * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);

        }
    }
}
