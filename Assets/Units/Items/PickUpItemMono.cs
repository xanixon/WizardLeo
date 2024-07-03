using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpItemMono : MonoBehaviour
{
    public int StackSize = 1;
    public virtual void PickUp(ref ItemStack stack, ref EcsEntity ownerEntity)
    {
        stack.ItemCount += StackSize;
    }
}
