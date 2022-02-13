using UnityEngine;

namespace Player.Old
{
   public class PlayerMove1 : MonoBehaviour
   {
      public float moveSpeed = 2f;
      private Rigidbody _rigidbody;
      public float jumpForce = 1f;
      public Transform _camera;
      private float _rotationX;
      public float sensetivity =2f;
      private bool _isGround;
      private void Start()
      {
         _rigidbody = GetComponent<Rigidbody>();
      }
      private void Update()
      {
         float mX = Input.GetAxis("Mouse X");
         float mY = Input.GetAxis("Mouse Y");
         bool jump = Input.GetKeyDown(KeyCode.Space);
         transform.localEulerAngles += Vector3.up * mX * sensetivity;
         _rotationX -= mY;
         _rotationX = Mathf.Clamp(_rotationX, 0, 60);
         _camera.localEulerAngles = new Vector3(_rotationX, 0, 0);
         if(jump && _isGround) Jump();
      }
      private void FixedUpdate()
      {
         float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");

         Vector3 direction = (transform.forward * v + transform.right * h)* moveSpeed;
         direction.y = _rigidbody.velocity.y;
         _rigidbody.velocity = direction;
      }
      private void Jump()
      {
         _isGround = false;
         _rigidbody.AddForce(Vector3.up* jumpForce,ForceMode.VelocityChange);
      }

      private void OnCollisionEnter(Collision collision)
      {
         for (int i = 0; i < collision.contactCount; i++)
         {
            if (collision.contacts[i].normal.y > .4f) _isGround = true;
         }
         print(collision.contacts[0].normal);
      }
   }
}
