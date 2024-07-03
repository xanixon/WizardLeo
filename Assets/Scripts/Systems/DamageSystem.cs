using Leopotam.Ecs;
using UnityEngine;

public class DamageSystem : IEcsRunSystem
{
    private EcsFilter<DamageEvent> _filter;
    public void Run()
    {
        foreach(int i  in _filter)
        {
            ref DamageEvent e = ref _filter.Get1(i);
            ref Health health = ref e.Target.Get<Health>();

            e.Target.Get<TakenDamage>();
            health.CurrentHealth -= e.Value;
            if(health.CurrentHealth <= 0 )
            {
                e.Target.Get<DeathEvent>();
            }
            _filter.GetEntity(i).Destroy();
        }
    }
}
