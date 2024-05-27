using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DarkBehaviour : AreaDmgWeaponBehaviour
{
    ShadowController shadowController;
    float scaleCircle;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject);
        shadowController = FindObjectOfType<ShadowController>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        scaleCircle=1+weaponData.Level/3;
        Vector3 scale= transform.localScale;
        //Vector3 rotation = transform.rotation.eulerAngles;
        scale.x=8*scaleCircle;
        scale.y=12*scaleCircle;

        transform.localScale= scale;
    }
}
