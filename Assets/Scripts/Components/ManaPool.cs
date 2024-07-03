
using UnityEngine;

public struct ManaPool 
{
    public int MaxMana;
    public float CurrentMana 
    { get { return _currentMana; } 
      set { _currentMana = Mathf.Clamp(value, 0, MaxMana); }
    }
    public float ManaRegen;

    private float _currentMana;
}
