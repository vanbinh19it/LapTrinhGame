using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject enemyData;
    
    [SerializeField] private float _currentCooldownDuration;
    [SerializeField] private float _enemyDmg;
    private void Awake() {
        _currentCooldownDuration=enemyData.CooldownDuration;
        _enemyDmg = enemyData.Damage;
    }
    // void OnCollierEnter2D(Collider2D other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         _currentCooldownDuration -= Time.fixedDeltaTime;
    //         if(_currentCooldownDuration < 0)
    //         {
    //             PlayerStats playerStats = other.GetComponent<PlayerStats>();
    //             playerStats.TakeDamage(_enemyDmg);
    //             _currentCooldownDuration=enemyData.CooldownDuration;
    //             Debug.Log("player-1");
    //         }
    //         Debug.Log("player");
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats.TakeDamage(_enemyDmg);
            _currentCooldownDuration=enemyData.CooldownDuration;
                
            
            
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            _currentCooldownDuration -= Time.fixedDeltaTime;
            if(_currentCooldownDuration < 0)
            {
                PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
                playerStats.TakeDamage(_enemyDmg);
                _currentCooldownDuration=enemyData.CooldownDuration;
                
            }
            
        }
    }
    
}
