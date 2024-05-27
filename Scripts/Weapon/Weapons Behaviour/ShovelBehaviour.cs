using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBehaviour : ProjectileWeaponBehaviour
{
    ShovelController shovelController;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        shovelController = FindObjectOfType<ShovelController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0)*shovelController.weaponData.Speed*Time.fixedDeltaTime;

        //Vector3 scale=transform.localScale;
        Vector3 rotation=transform.rotation.eulerAngles;

        float dirX= direction.x;
        float dirY= direction.y;
        if(dirX<0 && dirY==0) //left
        {
            rotation.z=90f;
        }
        else if(dirX==0 && dirY<0) //down
        {
            rotation.z=-180f;
        }
        else if(dirX==0 && dirY>0) //up
        {
            rotation.z=0f;
        }
        else if(dirX>0 && dirY>0) //right up
        {
            rotation.z=-45f;
        }
        else if (dirX>0 && dirY<0) //right down
        {
            rotation.z=-135f;
        }
        else if(dirX<0 && dirY>0) //left up
        {
            rotation.z=45f;
        }
        else if(dirX<0 && dirY<0) //left down
        {
            rotation.z=-225f;
        }


       // transform.localScale=scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
