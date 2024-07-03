using Leopotam.Ecs;
using UnityEngine;

public class EnemyFollowSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, Follow, AnimatorRef> _filter;
    private RuntimeData _runtimeData;
    private EcsWorld _ecsWorld;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref Enemy enemy = ref _filter.Get1(i);
            ref Follow follow = ref _filter.Get2(i);
            ref AnimatorRef animRef = ref _filter.Get3(i);

            if(!follow.Target.IsAlive())
            {
                ref var enemyEntity = ref _filter.GetEntity(i);
                enemyEntity.Del<Follow>();
                animRef.UnitAnimator.SetBool("Attack1", false);
                continue;
            }

            ref TransformRef transformRef = ref _runtimeData.Player.Get<TransformRef>();
            Vector3 targetPos = transformRef.UnitTransform.position;
            
            Vector3 dir = (targetPos - enemy.UnitTransform.position);
            float sqDistance = dir.sqrMagnitude;
            dir.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            enemy.UnitTransform.rotation = Quaternion.RotateTowards(enemy.UnitTransform.rotation, targetRot, enemy.RotationSpeed * Time.deltaTime);

            if(sqDistance < enemy.MeleeAttackDistance * enemy.MeleeAttackDistance)               
            {
                enemy.UnitNavMeshAgent.SetDestination(enemy.UnitTransform.position);
                if(Time.time >= follow.nextAttackTime)
                {
                    follow.nextAttackTime = Time.time + enemy.MeleeAttackInterval;
                    animRef.UnitAnimator.SetBool("Attack1", true);
                    animRef.UnitAnimator.SetBool("isRunning", false);
                }                
            }
            else
            {
                animRef.UnitAnimator.SetBool("Attack1", false);
                animRef.UnitAnimator.SetBool("isRunning", true);
                enemy.UnitNavMeshAgent.SetDestination(targetPos);
            }
        }       
    }   
}
