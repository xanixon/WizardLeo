using Leopotam.Ecs;
using UnityEngine;

public class PlayerTargetFinder : IEcsRunSystem
{
    private EcsFilter<EnemyProximityList> _proximityListFilter;
    private EcsFilter<HasTarget> _hasTargetFilter;
    private EcsWorld _ecsWorld;
    public void Run()
    {
        foreach (int i in _proximityListFilter)
        {
            ref EnemyProximityList enemyProximity = ref _proximityListFilter.Get1(i);
            foreach(int j in _hasTargetFilter)
            {
                int index = 0;
                ref HasTarget hasTarget = ref _hasTargetFilter.Get1(j);
                foreach(Enemy enemy in enemyProximity.ProximityList) 
                {
                    if (enemy.UnitTransform == null)
                        index++;
                }
                if (index < enemyProximity.ProximityList.Count)
                    hasTarget.Target = enemyProximity.ProximityList[0];
                else
                    hasTarget.Target = new Enemy();
            }
        }
    }
}
