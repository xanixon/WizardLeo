using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStackVisualSystem : IEcsRunSystem
{
    private EcsFilter<ItemStack, ItemStackUpdated> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref ItemStack stack = ref _filter.Get1(i);
            ref var entity = ref _filter.GetEntity(i);
            entity.Del<ItemStackUpdated>();

            for(int k = 0; k < stack.MaxItemCount; k++)
            {
                if (k > stack.ItemCount - 1)
                    stack.VisualStackObjects[k].SetActive(false);
                else
                    stack.VisualStackObjects[k].SetActive(true);
            }
        }
    }
}
