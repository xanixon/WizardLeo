using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, Player> _movementFilter;
    private EcsFilter<HasSpell, ManaPool, PlayerInputData, HasTarget> _castingFilter;
    public void Run()
    {
        foreach(int i in _movementFilter)
        {
            ref PlayerInputData input = ref _movementFilter.Get1(i);
            ref Player player = ref _movementFilter.Get2(i);            

            bool isRunning = true; 
            if(input.MoveInput == Vector3.zero) isRunning = false; 

            player.UnitAnimator.UnitAnimator.SetBool("isRunning", isRunning);
            player.UnitAnimator.UnitAnimator.SetBool("isCasting_1", input.isCasting);
        }

        foreach(int i in _castingFilter)
        {
            ref HasSpell hasSpell = ref _castingFilter.Get1(i);
            ref ManaPool manaPool = ref _castingFilter.Get2(i);
            ref PlayerInputData input = ref _castingFilter.Get3(i);
            ref HasTarget hasTarget = ref _castingFilter.Get4(i);
            SpellData spellData = hasSpell.SpellEntity.Get<SpellData>();


            if (input.MoveInput != Vector3.zero ||  //if player trying to move
                hasTarget.Target.UnitTransform == null) //or there is no target
                input.isCasting = false;
            else if (manaPool.CurrentMana >= spellData.ManaCost)
                input.isCasting = true;
            else
                input.isCasting = false;
        }
    }
}
