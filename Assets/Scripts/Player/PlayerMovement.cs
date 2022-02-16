using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Moving properties")]
        public float speedMoving = 5f;
        public float jumpHeight = 15f;
        
        [Header("GroundChecker")] 
        public Transform groundCheckPoint;
        public float checkRadius = .5f;
        public LayerMask whatIsGround;

        [Header("Physics")] 
        public float gravity = -9.81f;
        private Vector3 _velocity;

        private CharacterController _characterController;
        private bool _isGrounded = false;
        
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            CheckGround();
            UpdateVelocity();
        }

        public void Move(float left, float forward)
        {
            Vector3 direction = transform.right * left + transform.forward * forward;
            
            _characterController.Move(direction * (speedMoving * Time.deltaTime));
        }
        
        public void Jump()
        {
            if (!_isGrounded) return;

            _velocity.y += Mathf.Sqrt( jumpHeight * -2 * gravity); // скорость свободного падения, на оборот
        }

        private void UpdateVelocity()
        {
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = 0;
            }

            _velocity.y += gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
        }

        private void CheckGround()
        {
            _isGrounded = false;
            Collider[] colliders = Physics.OverlapSphere(groundCheckPoint.position, checkRadius, whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    _isGrounded = true;
                }
                
            }
        }
    }
}