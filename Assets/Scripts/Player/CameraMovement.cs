using System;
using UnityEngine;

namespace Player
{
    public class CameraMovement : MonoBehaviour
    {
        private void Update()
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -2f, 2f),
                transform.position.y,
                Mathf.Clamp(transform.position.z, -6f, 6f));
            
        }
    }
}