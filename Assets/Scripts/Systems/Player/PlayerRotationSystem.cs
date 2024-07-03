using Leopotam.Ecs;
using UnityEngine;

public class PlayerRotationSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, Player> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref PlayerInputData input = ref _filter.Get1(i);
            ref Player player = ref _filter.Get2(i);

            Vector3 lookDirection = input.MoveInput;
            if (lookDirection == Vector3.zero) return;

            lookDirection.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            player.PlayerTransform.rotation = Quaternion.RotateTowards(player.PlayerTransform.rotation, lookRotation, player.RotationSpeed * Time.deltaTime);
        }
    }
}
