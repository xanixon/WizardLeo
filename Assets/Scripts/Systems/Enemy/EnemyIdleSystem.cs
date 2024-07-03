using Leopotam.Ecs;
using UnityEngine;

public class EnemyIdleSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, AnimatorRef, Idle> _filter;
    private RuntimeData _runtimeData;
    public void Run()
    {
        foreach (int i in _filter)
        {
            if (!_runtimeData.Player.IsAlive()) break;
            ref Player player = ref _runtimeData.Player.Get<Player>();
            ref Enemy enemy = ref _filter.Get1(i);
            ref AnimatorRef animRef = ref _filter.Get2(i);
    
            Vector3 playerPosition = player.PlayerTransform.position;

            if (Vector3.SqrMagnitude(enemy.UnitTransform.position - playerPosition) <= enemy.TriggerDistance * enemy.TriggerDistance)
            {
                ref EcsEntity enemyEntity = ref _filter.GetEntity(i);
                enemyEntity.Del<Idle>();
                ref Follow follow = ref enemyEntity.Get<Follow>();
                follow.Target = _runtimeData.Player;
                animRef.UnitAnimator.SetBool("isRunning", true);
            }
        }
    }
}
