using UnityEngine;

namespace Enemies.ArrowTraps
{
   public class WallArrowSpawner : MonoBehaviour
   {
      public Transform muzzle;
      public GameObject arrowPrefab;
      public float delaySpawn = 1f;

      private void Start()
      {
         InvokeRepeating(nameof(CreateArrow),delaySpawn,delaySpawn);
      }

      private void CreateArrow()
      {
         Instantiate(arrowPrefab, muzzle.position, transform.rotation);
      }
   }
}
