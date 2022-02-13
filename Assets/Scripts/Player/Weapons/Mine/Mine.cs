using System.Collections;
using UnityEngine;

namespace Player.Weapons.Mine
{
   public class Mine : MonoBehaviour
   {
      public LayerMask layers;
      public float radiusExplosion = 3f;
      public float explosionForce = 1200f;
      public GameObject explosionEffect;

      [SerializeField] private float _timeDelay = 4f;
      private bool explose = false;
      private bool _canExplose = false;

      private void Start()
      {
         StartCoroutine(ExplosionDelay());
      }

      public void Explose()
      {
         if (!_canExplose) return;
         Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion, layers);
         for (int i = 0; i < colliders.Length; i++)
         {
            if (colliders[i].gameObject != gameObject && colliders[i].gameObject.GetComponent<Rigidbody>() != null)
            {
               explose = true;
               colliders[i].gameObject.GetComponent<Rigidbody>()
                  .AddExplosionForce(explosionForce, transform.position, radiusExplosion*3);
            }
         }
         if (explose)
         {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
         }
      }

      private void OnDrawGizmos()
      {
         Gizmos.DrawWireSphere(transform.position, radiusExplosion);
      }

      private IEnumerator ExplosionDelay()
      {
         yield return new WaitForSeconds(_timeDelay);
         _canExplose = true;



      }
   }
}
