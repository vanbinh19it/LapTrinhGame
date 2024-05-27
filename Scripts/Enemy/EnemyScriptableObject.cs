using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjec", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    float speed;
    public float Speed{get=>speed; private set=>speed=value; }
    [SerializeField]
    float maxHealth;
    public float MaxHealth{get=>maxHealth; private set=>maxHealth=value; }
    [SerializeField]
    float damage;
    public float Damage{get=>damage; private set=>damage=value; }
    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration{get=>cooldownDuration; private set=>cooldownDuration=value; }
    [SerializeReference]
    int exp;
    public int Exp{get=>exp; private set=>exp=value; }
}
