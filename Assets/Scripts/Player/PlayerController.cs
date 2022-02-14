using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float sensitivity = 2;
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float left = Input.GetAxis("Horizontal");
            float forward = Input.GetAxis("Vertical");

            _playerMovement.Move(left, forward);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMovement.Jump();
            }
            
            //RotateAround();
        }

        private void RotateAround()
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
    }
}