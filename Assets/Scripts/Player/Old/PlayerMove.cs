using UnityEngine;

namespace Player.Old
{
   public class PlayerMove : MonoBehaviour
   {
      public float moveSpeed = 2f;
      private Rigidbody _rigidbody;
      public float jumpForce = 1f;
      public Transform _camera;
      private float _rotationX;
   
   

      private void Start()
      {
         _rigidbody = GetComponent<Rigidbody>();
      }

      private void Update()
      {
      
         bool jump = Input.GetKeyDown(KeyCode.Space);
      



      }


      private void FixedUpdate()
      {
         float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");

         _rigidbody.velocity = new Vector3(h * moveSpeed, _rigidbody.velocity.y, v * moveSpeed);


      }
   }
}
