using System;
using UnityEngine;
using Player.Weapons.Bullet;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Aim _aim;
        public Transform muzzle;
        public Transform bulletFab;
        public Rigidbody mineFab;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) CreateBullet();
            else if (Input.GetKeyDown(KeyCode.E)) CreateMine();

        }

        private  void CreateBullet()
        {
            muzzle.LookAt(_aim._aimPosition);
            Instantiate(bulletFab, muzzle.position, muzzle.rotation);
        }

        [SerializeField] private float _mineDropPower = 2;
        private void CreateMine()
        {
            Vector3 dropDirection = (transform.forward + Vector3.up) * _mineDropPower;
            Instantiate(mineFab, muzzle.position, transform.rotation).velocity = dropDirection;
        }
    }
}
