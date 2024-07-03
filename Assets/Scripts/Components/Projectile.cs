using UnityEngine;

public struct Projectile 
{
    public GameObject ProjectileGO;
    public Vector3 Direction;
    public Vector3 PrevPosition;
    public float ProjectileSpeed;
    public float ProjectileRadius;
    public float ImpactDamage;
    public float SplashDamage;
    public float SplashRadius;
}
