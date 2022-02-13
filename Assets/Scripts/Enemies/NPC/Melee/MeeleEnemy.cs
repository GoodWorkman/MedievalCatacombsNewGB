using Player;
using Player.Old;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.NPC.Melee
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MeeleEnemy : MonoBehaviour
    {
        private Transform _player; // ГГ
        private NavMeshAgent _agent; // Враг

        private bool _isAngry = false; // тригерный флажок попадания в зону врага

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerMove1>().transform; // передаем координаты перемещения ГГ через компонент на нем
        }
        private void Update()
        {
            if (_isAngry==false) return; // if (!_isAngry) return; в ифе всегда должбыть тру
        
            _agent.SetDestination(_player.position); // при нахождении в зоне враг двигается к ГГ кажд update
        }

        public void Burn()
        {
            _isAngry = true;
        }

        public void Relax()
        {
            _isAngry = false;
            _agent.SetDestination(transform.position);
        
        }
    }
}
