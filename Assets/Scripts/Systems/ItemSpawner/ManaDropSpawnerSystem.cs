using Leopotam.Ecs;
using UnityEngine;

public class ManaDropSpawnerSystem : IEcsRunSystem
{
    private EcsFilter<ManaDropsSpawner> _filter;
    private SceneData _sceneData;
    public void Run()
    {
        foreach (int i in _filter)
        {
            ref ManaDropsSpawner spawner = ref _filter.Get1(i);


            if (Time.time < spawner.SpawnTime) continue;

            spawner.SpawnTime = Time.time + spawner.SpawnInterval;
            Vector3 spawnPosition = new Vector3(Random.Range(-_sceneData.SpawnArea.x, _sceneData.SpawnArea.x),
                                                             0,
                                                             Random.Range(-_sceneData.SpawnArea.y, _sceneData.SpawnArea.y));
            GameObject manaDropGO = Object.Instantiate(spawner.ManaDropsPrefab, spawnPosition, Quaternion.identity);
            GameObject.Destroy(manaDropGO, spawner.LifeTime);
        }
    }
}
