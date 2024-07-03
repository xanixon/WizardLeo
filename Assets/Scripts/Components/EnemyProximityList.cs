using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyProximityList 
{
    public int MaxSize;
    public List<Enemy> ProximityList;
    public float UpdateInterval;
    public float NextUpdateTime;
}
