using Leopotam.Ecs;
using UnityEngine;

public class EnemySpawnerInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private SkeletonSwordsmanStaticData _enemySpawnerStaticData;
    public void Init()
    {
        EcsEntity entity = _ecsWorld.NewEntity();
        ref EnemySpawner spawner = ref entity.Get<EnemySpawner>();
        spawner.EnemyPrefab = _enemySpawnerStaticData.UnitPrefab;
        spawner.SpawnInterval = _enemySpawnerStaticData.SpawnInterval;
        spawner.MaxEnemyCount = _enemySpawnerStaticData.MaxUnitsCount;
    }
}
