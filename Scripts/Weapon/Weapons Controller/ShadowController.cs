using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : WeaponController
{
    public int isSelect;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isSelect=1;
    }
    protected override void Update()
    {
        Attack();
    }
    protected override void Attack()
    {
        
        if (isSelect == 1)
        {
            base.Attack();
            GameObject shadow= Instantiate(weaponData.Prefab);
            //shadow.transform.position = transform.position;
            shadow.transform.parent = transform;
            isSelect=0;
        }
        
    }

    
}
