using Leopotam.Ecs;
using UnityEngine;

public class ItemStackSpreadOnDropSystem : IEcsRunSystem
{
    private EcsFilter<ItemStack, DroppedStack> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref ItemStack stack = ref _filter.Get1(i);
            ref var entity = ref _filter.GetEntity(i);
            entity.Del<DroppedStack>();
            entity.Get<ItemStackUpdated>();

            float spread = stack.DropSpread;
            for(int k = 0; k < stack.ItemCount; k++) 
            {
                GameObject ManaDropOnGround = GameObject.Instantiate(stack.ItemOnGroundPrefab, 
                                                                     stack.OwnerTransform.position + stack.DroppedSpawnPoint, 
                                                                     Quaternion.identity);
                Vector3 forceDirection = new Vector3(Random.Range(-spread, spread), 
                                                     Random.Range(0, spread), 
                                                     Random.Range(-spread, spread));
                ManaDropOnGround.GetComponent<Rigidbody>().AddForce(forceDirection);
                GameObject.Destroy(ManaDropOnGround, stack.LifeTimeOnDrop);
            }
            stack.ItemCount = 0;
        }
    }
}
