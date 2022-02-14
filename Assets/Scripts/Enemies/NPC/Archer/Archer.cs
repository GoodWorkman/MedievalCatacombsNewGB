using System.Collections;
using Player;
using Player.Old;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.NPC.Archer
{
   public class Archer : MonoBehaviour
   {
      public Transform[] path;

      private int _currentWayIndex = 0;
      private NavMeshAgent _agent;
      private Transform _player;
      private bool _isAngry = false;
  
      private void Awake()
      {
         _agent = GetComponent<NavMeshAgent>();
         _player = FindObjectOfType<PlayerMove1>().transform;
         _agent.SetDestination(path[_currentWayIndex].position);
         for (int i = 0; i < path.Length; i++)
         {
            path[i].parent = null; // распаренсиваем точки (выводим от родительского объекта)
         }
      }
      private void Update()
      {
         CheckPathStatus();
         if (_isAngry) _agent.SetDestination(_player.position);
      }
      private void CheckPathStatus()
      {
         /*bool needNextPoint = transform.position.x == path[_currentWayIndex].position.x &&
                              transform.position.z == path[_currentWayIndex].position.z; // точка назначения в конкретных координатах
                              */
         // расчет дистанции от точки до позиции объекта, на котором скрипт
         float targetDistance = Vector3.Distance(path[_currentWayIndex].position, transform.position); 
         // проверка расстояния на дистанцию до цели
         bool needNextPoint = targetDistance <= _agent.stoppingDistance;
         if (needNextPoint)
         {
            _currentWayIndex = _currentWayIndex + 1 == path.Length ? 0 : _currentWayIndex + 1;
            _agent.SetDestination(path[_currentWayIndex].position);
         }
      }
      public void Burn()
      {
         _isAngry = true;
      }
      public void Relax()
      {
         _isAngry = false;
         _agent.SetDestination(path[_currentWayIndex].position);
      }
   }
   
   
}
