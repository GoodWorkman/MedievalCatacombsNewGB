using UnityEngine;

namespace Player.Weapons.Bullet
{
    public class PlayerBullet : MonoBehaviour
    {
        public float speed = 2f;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            //transform.localPosition += transform.forward * speed * Time.deltaTime;
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
