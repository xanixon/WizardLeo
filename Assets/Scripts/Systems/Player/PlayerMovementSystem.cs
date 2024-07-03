using Leopotam.Ecs;
using UnityEngine;


public class PlayerMovementSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, Player> _filter; 
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref PlayerInputData input = ref _filter.Get1(i);
            ref Player player = ref _filter.Get2(i);

            Vector3 direction = input.MoveInput;
            player.PlayerRigidbody.AddForce(direction * player.MovementSpeed);
            
        }
    }
}
