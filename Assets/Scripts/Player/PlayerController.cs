using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float sensitivityPlayerRotation = 2;
        private PlayerMovement _playerMovement;
        public Transform playerCamera;
        
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
            
            if (left != 0 || forward != 0) RotateAround();
        }

        private void RotateAround()
        {
            Vector3 lookDirection = playerCamera.forward * Input.GetAxis("Vertical") +
                                    playerCamera.right * Input.GetAxis("Horizontal");
            lookDirection.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), sensitivityPlayerRotation);
        }
    }
}