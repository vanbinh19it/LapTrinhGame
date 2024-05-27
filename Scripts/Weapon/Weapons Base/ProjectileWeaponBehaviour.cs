using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public Vector2 direction;
    public float timeAfterDestroy;
    
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected float currentPiece;

    void Awake() {
       currentDamage = weaponData.Damage;
       currentSpeed = weaponData.Speed;
       currentCooldownDuration = weaponData.CooldownDuration;
       currentPiece = weaponData.Pierce; 
       
    }
    public float GetCurrentDamage()
    {
        return currentDamage*FindObjectOfType<PlayerStats>().CurrentMight;
    }

    protected virtual void Start()
    {
        Destroy(this.transform.parent.gameObject, timeAfterDestroy);
    }
    
    public void DirectionCheck(Vector2 dir)
    {
        direction=dir;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")==true)
        {
            //Debug.Log("currentDmg: " + currentDamage + "");
            EnemyStats enemy= other.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage());
            Destroy(this.transform.parent.gameObject);
        }
    }

    
}
