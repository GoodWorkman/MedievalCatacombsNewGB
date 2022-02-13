using UnityEngine;

namespace Enemies.NPC
{
   public class EnemySpawner : MonoBehaviour
   {
      public bool spawnOnStart = true;
      public Transform[] spawnPoints;
      public GameObject enemyPrefab; // сюда в инспекторе закладываем префаб врага

      private void Start()
      {
         if (spawnOnStart) CreateEnemies(); //включения спавна на 4 точках (добавлять через инспектор нужное кол-во точек)
      }

      public void CreateEnemies()
      {
         for (int i = 0; i < spawnPoints.Length; i++)
         {
            Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
         
         }
      }
   }
}
