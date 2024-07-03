using Leopotam.Ecs;
using UnityEngine;

public class EnemyDeathSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, AnimatorRef, DeathEvent> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref Enemy enemy = ref _filter.Get1(i);
            ref AnimatorRef anim = ref _filter.Get2(i);            
            anim.UnitAnimator.SetBool("isDead", true);
            enemy.UnitNavMeshAgent.isStopped = true;
            enemy.UnitCollider.enabled = false;
            if(enemy.ParentSpawner.IsAlive())
            {
                ref EnemySpawner spawner = ref enemy.ParentSpawner.Get<EnemySpawner>();
                spawner.CurrentEnemyCount--;
                GameObject.Destroy(enemy.UnitTransform.gameObject, 1);
            }

            ref EcsEntity enemyEntity = ref _filter.GetEntity(i);

            enemyEntity.Destroy();           
        }
    }
}
