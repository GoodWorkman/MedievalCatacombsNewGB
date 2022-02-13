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
      }

      private void Update()
      {
         CheckPathStatus();
         if (_isAngry) _agent.SetDestination(_player.position);
      }

      private void CheckPathStatus()
      {
      
         if (transform.position.x == path[_currentWayIndex].position.x &&
             transform.position.z == path[_currentWayIndex].position.z) //if (transform.position != path[_currentWayIndex].position) return;
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
