using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnShovel =Instantiate(weaponData.Prefab);
        spawnShovel.transform.position= this.transform.position;
        spawnShovel.transform.Find("Model").GetComponent<ShovelBehaviour>().DirectionCheck(playerMovement.lastMoveVector);
    }
}
