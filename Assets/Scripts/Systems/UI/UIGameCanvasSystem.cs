using Leopotam.Ecs;

public class UIGameCanvasSystem : IEcsRunSystem
{
    private EcsFilter<ManaPool, Health, Player> _playerManaFilter;
    private UI _ui;
    public void Run()
    {
        foreach(int i in _playerManaFilter)
        {
            ref ManaPool playerManaPool = ref _playerManaFilter.Get1(i);
            ref Health health = ref _playerManaFilter.Get2(i);
            //Since player has mana regeneration its necessary to update currentMana UI every frame
            _ui.ManaScreen.SetUIData(playerManaPool.CurrentMana, playerManaPool.MaxMana);
            _ui.HealthScreen.SetUIData(health.CurrentHealth, health.MaxHealth);
        }
    }
}
