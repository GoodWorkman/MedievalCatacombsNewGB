using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float left = Input.GetAxis("Horizontal");
            float forward = Input.GetAxis("Vertical");
            _playerMovement.Move(forward, left);
            if (Input.GetKeyDown(KeyCode.Space)) _playerMovement.Jump();
            
        }
    }
    
}