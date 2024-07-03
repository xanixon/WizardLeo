using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private PlayerStaticData _staticData;
    private SceneData _sceneData;
    private RuntimeData _runtimeData;
    public void Init()
    {
        EcsEntity playerEntity = _ecsWorld.NewEntity();

        ref Player player = ref playerEntity.Get<Player>();
        ref AnimatorRef animRef = ref playerEntity.Get<AnimatorRef>();
        ref PlayerInputData inputData = ref playerEntity.Get<PlayerInputData>();
        ref ManaPool mana = ref playerEntity.Get<ManaPool>();
        ref HasSpell hasSpell = ref playerEntity.Get<HasSpell>();       
        ref Health health = ref playerEntity.Get<Health>();
        ref TransformRef transformRef = ref playerEntity.Get<TransformRef>();
        ref HasTarget hasTarget = ref playerEntity.Get<HasTarget>();
        ref ItemPickup itemPickup = ref playerEntity.Get<ItemPickup>();
        ref ItemStack itemStack = ref playerEntity.Get<ItemStack>();

        GameObject playerGO = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.playerSpawnPoint.position, Quaternion.identity);        
        animRef.UnitAnimator = playerGO.GetComponentInChildren<Animator>();

        player.UnitAnimator = animRef;
        player.PlayerRigidbody = playerGO.GetComponent<Rigidbody>();
        player.PlayerTransform = playerGO.transform;       
        player.MovementSpeed = _staticData.MovementSpeed;
        player.RotationSpeed = _staticData.RotationSpeed;

        ManaSettings manaSettings = playerGO.GetComponent<ManaSettings>();
        mana.MaxMana = manaSettings.MaxMana;
        mana.ManaRegen = manaSettings.ManaRegen;
        mana.CurrentMana = mana.MaxMana;

        health.MaxHealth = _staticData.MaxHealth;
        health.CurrentHealth = health.MaxHealth;
        EcsEntity spellEntity = _ecsWorld.NewEntity();
        ref SpellData spellData = ref spellEntity.Get<SpellData>();
        SpellSettings spellSettings = playerGO.GetComponent<SpellSettings>();
        spellData.ProjectilePrefab = spellSettings.ProjectilePrefab;
        spellData.SpawnPoint = spellSettings.SpawnPoint;
        spellData.ProjectileSpeed = spellSettings.ProjectileSpeed;
        spellData.ProjectileRadius = spellSettings.ProjectileRadius;
        spellData.ImpactDamage = spellSettings.ImpactDamage;
        spellData.ManaCost = spellSettings.ManaCost;
        spellData.SplashDamage = spellSettings.SplashDamage;
        spellData.SplashRadius = spellSettings.SplashRadius;

        hasSpell.SpellEntity = spellEntity;
        _runtimeData.Player = playerEntity;
        transformRef.UnitTransform = playerGO.transform;

        itemPickup.PickupRadius = _staticData.ItemPickupRange;
        itemPickup.ItemLayer = _staticData.ItemLayer;

        itemStack.MaxItemCount = _staticData.MaxMana;
        itemStack.ItemInStackPrefab = _staticData.ManaStackItemPrefab;
        itemStack.ItemOnGroundPrefab = _staticData.ManaOnGroundItemPrefab;
        itemStack.SpawnPoint = _staticData.ManaStackSpawnPointOffset;
        itemStack.HorizontalNoise = _staticData.HorizontalNoise;
        itemStack.VerticalStep = _staticData.VerticalStep;
        itemStack.OwnerTransform = playerGO.transform;
        itemStack.DropSpread = _staticData.DropSpread;
        itemStack.DroppedSpawnPoint = _staticData.DroppedSpawnPoint;
        itemStack.VisualStackObjects = new List<GameObject>();
        itemStack.LifeTimeOnDrop = _staticData.LifeTimeOnDrop ;
        playerEntity.Get<ItemStackPrepared>();

        playerGO.GetComponentInChildren<PlayerSpellMediator>().PlayerEntity = playerEntity;
        
    }
}
