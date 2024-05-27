using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerScriptableObject", menuName="ScriptableObjects/Player" )]
public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject startWeapon;
    public GameObject StartWeapon{get=>startWeapon; set=>startWeapon=value; }
    [SerializeField]
    float speed;
    public float Speed{get=>speed; private set=>speed=value; }
    [SerializeField]
    float maxHealth;
    public float MaxHealth{get=>maxHealth; private set=>maxHealth=value; }
    [SerializeField]
    float recovery;
    public float Recovery{get=>recovery; private set=>recovery=value; }
    [SerializeField]
    int maxExp;
    public int MaxExp{get=>maxExp; private set=>maxExp=value; }
    [SerializeField]
    float might;
    public float Might{get=>might; private set=>might=value; }
    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed{get=>projectileSpeed; private set=>projectileSpeed=value; }
    [SerializeField]
    float magnet;
    public float Magnet{get=>magnet; private set=>magnet=value; }
    
}
