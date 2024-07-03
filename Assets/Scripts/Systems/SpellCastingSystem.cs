using Leopotam.Ecs;

public class SpellCastingSystem : IEcsRunSystem
{
    private EcsFilter<HasSpell, ManaPool, HasTarget, Cast> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref HasSpell hasSpell = ref _filter.Get1(i);
            ref ManaPool manaPool = ref _filter.Get2(i);
            ref HasTarget hasTarget = ref _filter.Get3(i);
            SpellData spell = hasSpell.SpellEntity.Get<SpellData>();

            if (manaPool.CurrentMana >= spell.ManaCost &&
                hasTarget.Target.UnitTransform != null)
            {
                manaPool.CurrentMana -= spell.ManaCost;
                ref SpawnProjectile spawnProj = ref hasSpell.SpellEntity.Get<SpawnProjectile>();
                spawnProj.Direction = hasTarget.Target.UnitTransform.position - spell.SpawnPoint.position;
            }

            ref EcsEntity castingEntity = ref _filter.GetEntity(i);
            castingEntity.Del<Cast>();
        }
    }
}
