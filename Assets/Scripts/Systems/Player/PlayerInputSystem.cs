using Leopotam.Ecs;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData> _filter;
    private EcsWorld _ecsWorld;
    public void Run()
    {
        foreach (int i in _filter)
        {
            ref PlayerInputData input = ref _filter.Get1(i);
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
           
            input.MoveInput = new Vector3(horizontal, 0, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _ecsWorld.NewEntity().Get<PauseEvent>();
            }
        }
    }
}
