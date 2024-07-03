using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSystem : IEcsRunSystem
{
    private EcsFilter<Player, AnimatorRef, DeathEvent> _filter;
    private RuntimeData _runtimeData;
    private UI _ui;
    public void Run()
    {
        foreach (int i in _filter)
        {
            ref var animatorRef = ref _filter.Get2(i);
            animatorRef.UnitAnimator.SetBool("isDead", true);
            _ui.DeathScreen.Show();
            _runtimeData.isGameOver = true;

           _filter.GetEntity(i).Destroy();
        }
    }
}
