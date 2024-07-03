using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private float _destroyDelay = 5;
    private void OnDestroy()
    {
        _deathEffect.SetActive(true);
        _deathEffect.transform.parent = null;
        Destroy(_deathEffect, _destroyDelay);
    }
}
