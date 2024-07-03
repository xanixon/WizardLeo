using Leopotam.Ecs;
using UnityEngine;

public class EnemyHitSystem : IEcsRunSystem
{
    private EcsFilter<Follow, Enemy, Hit> _filter;
    private EcsWorld _ecsWorld;
    public void Run()
    {
         foreach(int i  in _filter)
        {
            ref Follow follow = ref _filter.Get1(i);
            ref Enemy enemy = ref _filter.Get2(i);
            ref DamageEvent e = ref _ecsWorld.NewEntity().Get<DamageEvent>();
            e.Target = follow.Target;
            e.Value = enemy.MeleeDamage;
            ref EcsEntity entity = ref _filter.GetEntity(i);
            entity.Del<Hit>();
        }
    }
}
