using System.Collections.Generic;
using UnityEngine;

public struct ItemStack
{
    public int ItemCount
    {
        get { return _itemCount; }
        set { _itemCount = Mathf.Clamp(value, 0, MaxItemCount); }
    }
    public int MaxItemCount;
    public GameObject ItemInStackPrefab;
    public GameObject ItemOnGroundPrefab;
    public Vector3 SpawnPoint;
    public Vector3 DroppedSpawnPoint;
    public float VerticalStep; //every item on stack spawns a little higher than previous one
    public float HorizontalNoise;
    public float DropSpread;
    public float LifeTimeOnDrop;
    public Transform OwnerTransform;
    public List<GameObject> VisualStackObjects;

    private int _itemCount;
}
