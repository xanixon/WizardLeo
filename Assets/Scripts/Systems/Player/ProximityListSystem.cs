using Leopotam.Ecs;
using UnityEngine;

public class ProximityListSystem : IEcsRunSystem
{
    private EcsFilter<Enemy>.Exclude<DeathEvent> _filter;
    private EcsFilter<EnemyProximityList> _proximityListFilter;
    private RuntimeData _runtimeData;

    public void Run()
    {
        if (!_runtimeData.Player.IsAlive()) return;
        foreach (int i in _proximityListFilter)
        {
            ref EnemyProximityList proximityList = ref _proximityListFilter.Get1(i);
            ref EcsEntity playerEntity = ref _runtimeData.Player;

            if (Time.time < proximityList.NextUpdateTime ||
                !playerEntity.IsAlive())
                continue;

            proximityList.NextUpdateTime = Time.time + proximityList.UpdateInterval;

            Player player = playerEntity.Get<Player>();
            Vector3 playerPosition = player.PlayerTransform.position;
            proximityList.ProximityList.Clear();

            foreach(int j in _filter)
            {
                if (proximityList.ProximityList.Count >= proximityList.MaxSize) break;
                ref Enemy enemy = ref _filter.Get1(j);
                float distance = Vector3.SqrMagnitude(enemy.UnitTransform.position - player.PlayerTransform.position);
                enemy.DistanceToPlayer = distance;
                proximityList.ProximityList.Add(enemy);
            }
            proximityList.ProximityList.Sort((x,y) => x.DistanceToPlayer.CompareTo(y.DistanceToPlayer));
        }
    }
}
