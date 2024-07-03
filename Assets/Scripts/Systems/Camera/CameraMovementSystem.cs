using Leopotam.Ecs;
using UnityEngine;

public class CameraMovementSystem : IEcsRunSystem
{
    private EcsFilter<Player> _filter;
    private PlayerStaticData _staticData;
    private SceneData _sceneData;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref Player player = ref _filter.Get1(i);

            
            Vector3 desiredPosition = player.PlayerTransform.position + _staticData.CameraOffset;
            Vector3 cameraPosition = _sceneData.SceneCamera.transform.position;
            float distanceToPlayer = Vector3.Distance(cameraPosition, desiredPosition);
            if(distanceToPlayer > _staticData.CameraFollowDelay)
                _sceneData.SceneCamera.transform.position = Vector3.Lerp(_sceneData.SceneCamera.transform.position,
                                                                         desiredPosition, 
                                                                         _staticData.CameraSmoothness * Time.deltaTime);
        }
    }
}
