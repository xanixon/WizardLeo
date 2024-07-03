using Leopotam.Ecs;
using System.Collections.Generic;

public class ProximityListInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private PlayerStaticData _playerStaticData;
    public void Init()
    {
        ref EnemyProximityList proximityList = ref _ecsWorld.NewEntity().Get<EnemyProximityList>();
        proximityList.ProximityList = new List<Enemy>();
        proximityList.MaxSize = _playerStaticData.ProximityListMaxSize;
        proximityList.UpdateInterval = _playerStaticData.ProximityListUpdateInterval;
    }
}
