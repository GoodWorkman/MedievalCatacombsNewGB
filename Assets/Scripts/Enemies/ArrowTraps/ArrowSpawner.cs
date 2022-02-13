using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.ArrowTraps
{
    public class ArrowSpawner : MonoBehaviour
    {
        public Transform point1;
        public Transform point2;
        public GameObject arrowPrefab;
        public float delaySpawn=0.5f;


        private void Start()
        {
            InvokeRepeating(nameof(CreateArrow), delaySpawn,delaySpawn);
        }


        private void CreateArrow()
        {
            Instantiate(arrowPrefab,
                new Vector3(
                    Random.Range(point1.position.x, point2.position.x), 
                    Random.Range(point1.position.y, point2.position.y), 
                    Random.Range(point1.position.z,point2.position.z)), transform.rotation); // transform rotation  дает поворот не по умолчанию,
            // а по пустышке спавнеру, на которой висит скрипт
        }





    }
}
