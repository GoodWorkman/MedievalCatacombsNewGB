using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public Transform muzzle;
        public GameObject bulletFab;
        public Rigidbody mineFab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) CreateBullet();
            else if (Input.GetKeyDown(KeyCode.E)) CreateMine();

        }

        private  void CreateBullet()
        {
            Instantiate(bulletFab, muzzle.position, transform.rotation);
        }

        [SerializeField] private float _mineDropPower = 2;
        private void CreateMine()
        {
            Vector3 dropDirection = (transform.forward + Vector3.up) * _mineDropPower;
            Instantiate(mineFab, muzzle.position, transform.rotation).velocity = dropDirection;
        }
    }
}
