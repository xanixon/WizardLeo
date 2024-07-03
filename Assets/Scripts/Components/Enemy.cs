using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct Enemy
{
    public NavMeshAgent UnitNavMeshAgent;
    public AnimatorRef UnitAnimator;
    public EcsEntity ParentSpawner;
    public Transform UnitTransform;
    public Collider UnitCollider;
    public float MeleeAttackDistance;
    public int MeleeDamage;
    public float TriggerDistance;
    public float MeleeAttackInterval;
    public float RotationSpeed;
    public float DistanceToPlayer;
}
