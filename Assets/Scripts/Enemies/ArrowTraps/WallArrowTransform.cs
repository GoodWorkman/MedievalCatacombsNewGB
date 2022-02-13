using Player;
using Player.Old;
using UnityEngine;

namespace Enemies.ArrowTraps
{
    public class WallArrowTransform : MonoBehaviour
    {
        [SerializeField] private float _damage = 1;
        public float speed = 4f;
        public float timeDelay = 3f;
        private Rigidbody _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            //transform.Translate(Vector3.forward *Time.deltaTime*speed);
            //_rigidbody.velocity = Vector3.forward*speed;?? не робит

            transform.localPosition += transform.forward * Time.deltaTime * speed;
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision with " + collision.gameObject.name);


            //PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            //collision.rigidbody == null;

            if (collision.rigidbody) //!= null)
            {
                print("1");
                /*PlayerHealth playerHealth = collision.rigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                print("2");
                playerHealth.TakeDamage(_damage);
            }*/
                if (collision.rigidbody.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.TakeDamage(_damage);
                }
            }

            Destroy(gameObject);

        }
    }
}


    