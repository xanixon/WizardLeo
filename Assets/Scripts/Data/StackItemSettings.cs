using UnityEngine;

public abstract class StackItemSettings : ScriptableObject
{
    public int ItemCount;
    public int MaxItemCount;
    public GameObject ItemPrefab;
    public Vector3 SpawnPointOffset;
    public int VerticalStep; //every item on stack spawns a little higher than previous one
    public float HorizontalNoise;
}
