using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData")]
public class ZombieData : ScriptableObject
{
    [SerializeField] float chaseRange;
    public float ChaseRange { get { return chaseRange; } }

    [SerializeField] float attackRange;
    public float AttackRange { get { return attackRange; } }

    [SerializeField] int atk;
    public float Atk { get { return atk; } }

    [SerializeField] int currentHp;
    public float CurrentHp { get { return currentHp; } }

    [SerializeField] int maxHp;
    public float MaxHp { get { return maxHp; } }
}
