using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStackDropSystem : IEcsRunSystem
{
    private EcsFilter<ItemStack, TakenDamage> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref var entity = ref _filter.GetEntity(i);
            entity.Get<DroppedStack>();
            entity.Del<TakenDamage>();
        }
    }

   
}
