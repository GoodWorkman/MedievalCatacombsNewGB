using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public class TriggerHandler : MonoBehaviour
    {
        public UnityEvent onTriggerEnter;
        public UnityEvent onTriggerExit;
    
        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            onTriggerExit.Invoke();
        }
    }
}
