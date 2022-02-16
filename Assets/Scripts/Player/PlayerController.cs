using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Smooth player rotation")]
        public float sensitivityPlayerRotation = 0.05f;
        public Transform playerCamera;
        
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
            
            RotateAround(left, forward);
        }

        private void RotateAround(float left, float forward)
        {
            if (left == 0 && forward == 0) return;
            
            Vector3 lookDirection = (playerCamera.forward * forward) + (playerCamera.right * left);
            lookDirection.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), sensitivityPlayerRotation);
        }
    }
}