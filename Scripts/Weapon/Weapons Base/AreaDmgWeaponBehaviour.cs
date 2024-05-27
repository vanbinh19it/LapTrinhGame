using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaDmgWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float timeAfterDestroy;
    public bool isDestroy;

    protected float currentDamage;
    protected float currentCooldownDuration;
    protected float currentPierce;
    // Start is called before the first frame update
    // protected virtual void Start()
    // {
    //     Destroy(this.gameObject, timeAfterDestroy);
    // }
    private void Awake() {
        currentDamage=weaponData.Damage;
        currentCooldownDuration=0;
        currentPierce = weaponData.Pierce;

    }
    public float GetCurrentDamage()
    {
        return currentDamage*FindObjectOfType<PlayerStats>().CurrentMight;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    // protected virtual void OnTriggerEnter2D(Collider2D other) {
    //     if(other.CompareTag("Enemy")==true)
    //     {
    //         EnemyStats enemy = other.GetComponent<EnemyStats>();
    //         enemy.TakeDamage(currentDamage);
            
    //     }
    //     // if(other.CompareTag("Enemy"))
    //     // Debug.Log("vào");
    // }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.CompareTag("Enemy")==true)
        {
            currentCooldownDuration -= Time.fixedDeltaTime;
            if(currentCooldownDuration < 0)
            {
                EnemyStats enemy = other.GetComponent<EnemyStats>();
                enemy.TakeDamage(GetCurrentDamage());
                currentCooldownDuration=weaponData.CooldownDuration;
                Debug.Log("-1");
            }
            
            
        }
    }

}
