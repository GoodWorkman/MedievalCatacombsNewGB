using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public Transform muzzle;
        public GameObject bulletFab;
        public GameObject mineFab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) CreateBullet();
            else if (Input.GetKeyDown(KeyCode.E)) CreateMine();

        }

        private  void CreateBullet()
        {
            Instantiate(bulletFab, muzzle.position, transform.rotation);
        }
    
        private void CreateMine()
        {
            Instantiate(mineFab, muzzle.position, transform.rotation);
        }
    }
}
