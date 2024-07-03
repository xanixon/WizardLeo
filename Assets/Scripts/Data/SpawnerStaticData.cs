using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SpawnerStaticData : ScriptableObject
{
    public GameObject UnitPrefab;
    public float SpawnInterval;
    public int MaxUnitsCount;
}
