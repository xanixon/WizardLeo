using Leopotam.Ecs;

public class ManaDropSpawnerInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private ManaSpawnerStaticData _manaDropsSpawnerData;
    public void Init()
    {
        ref ManaDropsSpawner manaSpawner = ref _ecsWorld.NewEntity().Get<ManaDropsSpawner>();
        manaSpawner.ManaDropsPrefab = _manaDropsSpawnerData.UnitPrefab;
        manaSpawner.SpawnInterval = _manaDropsSpawnerData.SpawnInterval;
        manaSpawner.LifeTime = _manaDropsSpawnerData.LifeTime;
    }
}
