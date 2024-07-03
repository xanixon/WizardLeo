using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectileSystem : IEcsRunSystem
{
    private EcsFilter<SpellData, SpawnProjectile> _filter; 
    private EcsWorld _ecsWorld;

    public void Run()
    {
        foreach(int i in _filter)
        {
            ref SpellData spellData = ref _filter.Get1(i);
            ref SpawnProjectile spawnProjectile = ref _filter.Get2(i);

            GameObject projectileGO = Object.Instantiate(spellData.ProjectilePrefab, spellData.SpawnPoint.position, Quaternion.identity);
            EcsEntity projectileEntity = _ecsWorld.NewEntity();
            ref Projectile proj = ref projectileEntity.Get<Projectile>();

            proj.ProjectileGO = projectileGO;
            proj.Direction = spawnProjectile.Direction.normalized;

            proj.ProjectileSpeed = spellData.ProjectileSpeed;
            proj.PrevPosition = projectileGO.transform.position;
            proj.ImpactDamage = spellData.ImpactDamage;
            proj.ProjectileRadius = spellData.ProjectileRadius;
            proj.SplashRadius = spellData.SplashRadius;
            proj.SplashDamage = spellData.SplashDamage;

            ref EcsEntity castingEntity = ref _filter.GetEntity(i);
            castingEntity.Del<SpawnProjectile>();
        }
    }
}
