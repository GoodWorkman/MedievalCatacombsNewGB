using System;
using System.Collections;
using System.Collections.Generic;
using Player.Old;
using UnityEngine;

public class AtackTrigger : MonoBehaviour
{
    [SerializeField] private Attack _attack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == false) return;
        
        if(other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
            _attack.StartAttack(playerHealth);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == false) return;
        
        if(other.attachedRigidbody.GetComponent<PlayerHealth>())
            _attack.StopAttack();
    }
}
