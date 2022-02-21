using System.Collections;
using System.Collections.Generic;
using Player.Old;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string IsAttack = "IsAttack";
    [SerializeField] private float _damageValue;
    private PlayerHealth _playerHealth;

    public void StartAttack(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
        _animator.SetBool(IsAttack, true);
    }
    
    public void MakeDamage()
    {
        _playerHealth.TakeDamage(_damageValue);
    }

    public void StopAttack()
    {
        _animator.SetBool(IsAttack, false);
    }
}
