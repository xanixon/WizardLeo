using Leopotam.Ecs;
using UnityEngine;

public class StackItemsCashingSystem : IEcsRunSystem
{
    private EcsFilter<ItemStack, ItemStackPrepared> _filter;
    public void Run()
    {
       foreach(int i in _filter)
        {
            ref ItemStack stack = ref _filter.Get1(i);
            ref var entity = ref _filter.GetEntity(i);
            entity.Del<ItemStackPrepared>();

            float noize = stack.HorizontalNoise;
            float step = stack.VerticalStep;
            for (int k = 0; k < stack.MaxItemCount; k++)
            {                
                GameObject stackVisualItem = GameObject.Instantiate(stack.ItemInStackPrefab, stack.OwnerTransform);

                Vector3 localSpawnPosition = stack.SpawnPoint + new Vector3(Random.Range(-noize, noize), step * k, Random.Range(-noize, noize));
                stackVisualItem.transform.localPosition = localSpawnPosition;
                stack.VisualStackObjects.Add(stackVisualItem);
                stackVisualItem.SetActive(false);
            }
        }
    }
}
