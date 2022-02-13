using UnityEngine;

namespace Enemies.Crossbow
{
    public class Crossbow : MonoBehaviour
    {
        public Transform partToRotate;
        public Transform target;
        public Transform muzzle;
        public Transform arrowPrefab;
    
    
        private void Update()
        {
            partToRotate.LookAt(target);
       
        }

        private void CreateArrow()
        {
        
        }
    }
}
