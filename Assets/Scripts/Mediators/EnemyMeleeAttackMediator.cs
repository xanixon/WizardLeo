using Leopotam.Ecs;
using UnityEngine;

public class EnemyMeleeAttackMediator : MonoBehaviour
{
    public EcsEntity Enemy;

    public void HitTheTarget()
    {
        if(Enemy.IsAlive())
           Enemy.Get<Hit>();
    }
}
