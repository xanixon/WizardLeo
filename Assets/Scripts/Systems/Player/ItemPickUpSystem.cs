using Leopotam.Ecs;
using UnityEngine;

public class ItemPickUpSystem : IEcsRunSystem
{
    private EcsFilter<Player, ItemPickup, ItemStack> _filter;
    private RuntimeData _runtimeData;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref Player player = ref _filter.Get1(i);
            ref ItemPickup itemPickup = ref _filter.Get2(i);
            ref ItemStack itemStack = ref _filter.Get3(i);

            Vector3 playerPosition = player.PlayerTransform.position;
            Collider[] itemsToPickup = Physics.OverlapSphere(playerPosition, itemPickup.PickupRadius, itemPickup.ItemLayer);
            foreach(Collider col in itemsToPickup)
            {
                PickUpItemMono item;
                if (col.TryGetComponent<PickUpItemMono>(out item))
                {
                    ref EcsEntity stackEntity = ref _filter.GetEntity(i);
                    item.PickUp(ref itemStack, ref stackEntity);
                    stackEntity.Get<ItemStackUpdated>();
                }
                GameObject.Destroy(col.gameObject);
            }
        }
        
    }
}
