using Leopotam.Ecs;
using UnityEngine;

public class UnitManaSystem : IEcsRunSystem
{
    private EcsFilter<ManaPool, ItemStack> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref ManaPool manaPool = ref _filter.Get1(i);
            ref ItemStack stack = ref _filter.Get2(i);

            manaPool.MaxMana = stack.ItemCount;
            if(manaPool.CurrentMana < manaPool.MaxMana)
                manaPool.CurrentMana = Mathf.Clamp(manaPool.CurrentMana + manaPool.ManaRegen * Time.deltaTime, 
                                                   0, 
                                                   manaPool.MaxMana);

        }

        
    }
}
