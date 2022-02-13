using UnityEngine;

namespace Enemies.NPC.Melee
{
    public class AngryZone : MonoBehaviour
    {
        public MeeleEnemy meeleEnemy;
        private void OnTriggerEnter(Collider other)
        {
            meeleEnemy.Burn();
        }
        private void OnTriggerExit(Collider other)
        {
            meeleEnemy.Relax();
        }
    }
}
/*
ИЗМЕНИЛИ СЛОИ (тригерзону как слой 6, Игрока как зону 5, пересечение 6 слоя только с 5 в настройках проекта)
, тем самым код ниже не нужен
НО ЕСЛИ СЛОИ НЕ МЕНЯТЬ, ТО КОД НИЖЕ 
public class MeeleEnemyAngryZone : MonoBehaviour
{
    public MeeleEnemy meeleEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody) //!= null)
        {                        
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                meeleEnemy.Burn();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody) //!= null)
        {
            print("1");
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                meeleEnemy.Relax();
            }
        }
    }
}*/