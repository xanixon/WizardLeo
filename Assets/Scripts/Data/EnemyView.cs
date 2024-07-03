using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EcsEntity entity;

    public NavMeshAgent UnitNavMeshAgent;
    public Animator UnitAnimator;
    public Collider UnitCollider;
    public float MeleeAttackDistance;
    public int MeleeDamage;
    public float TriggerDistance;
    public float MeleeAttackInterval;
    public int MaxHealth;
    public float RotationSpeed;
}
