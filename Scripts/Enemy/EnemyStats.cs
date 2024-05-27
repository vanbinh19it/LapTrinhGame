using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    public EnemyScriptableObject enemyData;
    [HideInInspector] public float currentMoveSpeed;
    float currentHealth;
    float currentDamage;
    private PlayerStats _playerStats;
    public float despawnDistance =20f;
    Transform player;
    private void Awake() {
        currentMoveSpeed=enemyData.Speed;
        currentHealth= enemyData.MaxHealth;
        currentDamage= enemyData.Damage;
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    void Start() {
        player= FindObjectOfType<PlayerStats>().transform;

    }
    void Update() {
        if(Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }

    private void ReturnEnemy()
    {
        EnemySpawner es= FindObjectOfType<EnemySpawner>();
        transform.position= player.position+ es.relativeSpawnPosition[UnityEngine.Random.Range(0, es.relativeSpawnPosition.Count)].position;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth = currentHealth - dmg;
        if(currentHealth == 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        _playerStats.GetExp(enemyData.Exp);
        Destroy(this.gameObject);
    }
    private void OnDestroy() {
        if(!gameObject.scene.isLoaded)
        {
            return;
        }
        
        EnemySpawner es= FindObjectOfType<EnemySpawner>();
        Debug.LogWarning(es);
        es.OnEnemyKilled();
        
        
    }
}
