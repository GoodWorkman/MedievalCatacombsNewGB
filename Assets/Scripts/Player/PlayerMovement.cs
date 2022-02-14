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
        
        [Header("Camera follow")] 
        public Transform cameraPosition;
        
        private Rigidbody _rigidbody;
        private bool _isGrounded = false;

        private float _smoothVelocityRotation = 0;
        private float _smoothTimeRotation = 0.1f;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        public void Move(float left, float forward)
        {

            float targetAngel = Mathf.Atan2(left, forward) * Mathf.Rad2Deg + cameraPosition.eulerAngles.y;
            float smoothAngel = Mathf.SmoothDampAngle(
                transform.eulerAngles.y, 
                targetAngel,
                ref _smoothVelocityRotation, 
                _smoothTimeRotation);
                transform.rotation = Quaternion.Euler(0, smoothAngel, 0
                );
                
            Vector3 moveDirection = Quaternion.Euler(0,smoothAngel,0) * Vector3.forward * speedMoving;
            moveDirection = moveDirection.normalized;
            _rigidbody.velocity = new Vector3(moveDirection.x, _rigidbody.velocity.y, moveDirection.z);
        }

        public void Jump()
        {
            if (!_isGrounded) return;
            _rigidbody.AddForce(Vector3.up * jumpForce);
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