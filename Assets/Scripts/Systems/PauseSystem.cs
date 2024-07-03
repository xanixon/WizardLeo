
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : IEcsRunSystem
{
    private EcsFilter<PauseEvent> _filter;
    private RuntimeData _runtimeData;
    private UI _ui;

    public void Run()
    {
        foreach(int i in _filter)
        {
            _filter.GetEntity(i).Del<PauseEvent>();
            _runtimeData.isPaused = !_runtimeData.isPaused;
            _ui.PauseScreen.Show(_runtimeData.isPaused);
            Time.timeScale = _runtimeData.isPaused ? 0f : 1f;
        }
    }
}
