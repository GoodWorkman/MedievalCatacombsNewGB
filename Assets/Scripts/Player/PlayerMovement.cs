using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speedMoving = 5f;
        public float jumpForce = 15f;
        [Header("GroundChecker")] 
        public Transform groundCheckPoint;
        public float checkRadius = .5f;
        public LayerMask whatIsGround;
        
        private Rigidbody _rigidbody;
        private bool _isGrounded = false;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
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

        public void Move(float forward, float left)
        {
            _rigidbody.velocity = new Vector3(left * speedMoving, _rigidbody.velocity.y, forward * speedMoving);
        }

        public void Jump()
        {
            if (!_isGrounded) return;
            _rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}