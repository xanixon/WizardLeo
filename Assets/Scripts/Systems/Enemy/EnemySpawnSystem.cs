using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : IEcsRunSystem
{
    private EcsFilter<EnemySpawner> _filter;
    private EcsWorld _ecsWorld;
    private SceneData _sceneData;
    private RuntimeData _runtimeData;
    public void Run()
    {
        if (_runtimeData.isGameOver) return;
        foreach (int i in _filter)
        {

            ref EnemySpawner spawner = ref _filter.Get1(i);


            if(Time.time < spawner.SpawnTime || 
               spawner.CurrentEnemyCount >= spawner.MaxEnemyCount) continue;

            spawner.SpawnTime = Time.time + spawner.SpawnInterval;
            Vector3 spawnPosition = new Vector3(Random.Range(-_sceneData.SpawnArea.x, _sceneData.SpawnArea.x),
                                                             0,
                                                             Random.Range(-_sceneData.SpawnArea.y, _sceneData.SpawnArea.y));
            GameObject enemyGO = Object.Instantiate(spawner.EnemyPrefab, spawnPosition, Quaternion.identity);
            EnemyView enemyView = enemyGO.GetComponent<EnemyView>();
            var enemyEntity = _ecsWorld.NewEntity();
            ref Enemy enemy = ref enemyEntity.Get<Enemy>();
            ref Health health = ref enemyEntity.Get<Health>();
            ref AnimatorRef animRef = ref enemyEntity.Get<AnimatorRef>();
            animRef.UnitAnimator = enemyView.UnitAnimator;
            enemyEntity.Get<Idle>();
            enemyView.entity = enemyEntity;

            enemy.UnitNavMeshAgent = enemyView.UnitNavMeshAgent;
            enemy.UnitAnimator = animRef;
            enemy.UnitTransform = enemyView.transform;
            health.CurrentHealth = enemyView.MaxHealth;
            enemy.MeleeDamage = enemyView.MeleeDamage;
            enemy.MeleeAttackInterval = enemyView.MeleeAttackInterval;
            enemy.MeleeAttackDistance = enemyView.MeleeAttackDistance;
            enemy.TriggerDistance = enemyView.TriggerDistance;
            enemy.RotationSpeed = enemyView.RotationSpeed;
            enemy.UnitCollider = enemyView.UnitCollider;
            enemy.ParentSpawner = _filter.GetEntity(i);

            enemyView.GetComponentInChildren<EnemyMeleeAttackMediator>().Enemy = enemyEntity;
            spawner.CurrentEnemyCount++;
        }
    }
}
