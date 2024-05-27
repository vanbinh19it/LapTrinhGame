using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon stats")]
    public WeaponScriptableObject weaponData;
    // public GameObject prefab;
    // public float damage;
    // public float speed;
    // public float cooldownDuration;
    private float currentCooldown;

    protected PlayerMovement playerMovement;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
        currentCooldown=weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown-=Time.deltaTime;

        if (currentCooldown < 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown=weaponData.CooldownDuration;
    }
}
