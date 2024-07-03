using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    [SerializeField] private EcsUiEmitter _uiEmitter;
    [SerializeField] private PlayerStaticData Configuration;
    [SerializeField] private SkeletonSwordsmanStaticData SkeletonSwordsmanData;
    [SerializeField] private ManaSpawnerStaticData ManaSpawnerStaticData;
    [SerializeField] private SceneData SceneData;
    [SerializeField] private UI Ui;
    private EcsWorld _ecsWorld;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _updateSystems = new EcsSystems(_ecsWorld);
        _fixedUpdateSystems = new EcsSystems(_ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        _updateSystems            
            .Add(new PlayerInitSystem())
            //.Add(new PlayerInputSystem())
            .Add(new PlayerRotationSystem())
            .Add(new PlayerAnimationSystem())
            .Add(new PlayerDeathSystem())
            .Add(new PlayerTargetFinder())
            .Add(new CameraMovementSystem())
            .Add(new ProjectileControlSystem())
            .Add(new SpawnProjectileSystem())
            .Add(new ProjectileHitSystem())
            .Add(new SpellCastingSystem())         
            .Add(new UnitManaSystem())
            .Add(new UIGameCanvasSystem())
            .Add(new PauseSystem())
            .Add(new EnemySpawnerInitSystem())
            .Add(new EnemySpawnSystem())
            .Add(new EnemyIdleSystem())
            .Add(new EnemyFollowSystem())
            .Add(new EnemyHitSystem())
            .Add(new EnemyDeathSystem())
            .Add(new ItemStackDropSystem())
            .Add(new DamageSystem())
            .Add(new ProximityListInitSystem())
            .Add(new ProximityListSystem())   
            .Add(new ManaDropSpawnerInitSystem())
            .Add(new ManaDropSpawnerSystem())
            .Add(new ItemPickUpSystem())
            .Add(new StackItemsCashingSystem())
            .Add(new ItemStackVisualSystem())   
            .Add(new ItemStackSpreadOnDropSystem())
            .Add(new UIJoysticControlSystem())
            .Add(new UIRestartSystem())
            .Inject(Configuration)
            .Inject(SkeletonSwordsmanData)
            .Inject(ManaSpawnerStaticData)
            .Inject(SceneData)
            .Inject(runtimeData)
            .Inject(Ui)
            .InjectUi(_uiEmitter)
            .Init();

        _fixedUpdateSystems
            .Add(new PlayerMovementSystem())
            .Inject(Configuration)
            .Inject(SceneData)
            .Inject(runtimeData)
            .Inject(Ui)
            .Init();

    }


    private void Update()
    {
        _updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;
        _fixedUpdateSystems?.Destroy();
        _fixedUpdateSystems = null;
        _ecsWorld.Destroy();
        _ecsWorld = null;
    }
}
