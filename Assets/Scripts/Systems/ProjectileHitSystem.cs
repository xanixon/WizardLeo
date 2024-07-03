using Leopotam.Ecs;
using UnityEngine;

public class ProjectileHitSystem : IEcsRunSystem
{
    private EcsFilter<Projectile, ProjectileHit> _filter;
    private EcsWorld _ecsWorld;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref Projectile proj = ref _filter.Get1(i);
            ref ProjectileHit hitInfo = ref _filter.Get2(i);

            if(hitInfo.HitInfo.collider.TryGetComponent<EnemyView>(out EnemyView enemyView))
            {
                if (enemyView.entity.IsAlive())
                {
                    ref var e = ref _ecsWorld.NewEntity().Get<DamageEvent>();
                    e.Target = enemyView.entity;
                    e.Value = proj.ImpactDamage;
                }
            }

            //SplashDamage
            Collider[] victims = Physics.OverlapSphere(proj.ProjectileGO.transform.position, proj.SplashDamage);
            foreach(Collider col in victims)
            {
                if(col.TryGetComponent<EnemyView>(out EnemyView splashVictims))
                {
                    if(splashVictims.entity.IsAlive())
                    {
                        ref var e = ref _ecsWorld.NewEntity().Get<DamageEvent>();
                        e.Target = splashVictims.entity;
                        e.Value = proj.SplashDamage;
                    }
                }
            }
            GameObject.Destroy(proj.ProjectileGO);
            _filter.GetEntity(i).Destroy();
        }
    }
}
