using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Actions;
using Leopotam.Ecs.Ui.Components;
using UnityEngine.SceneManagement;

public class UIRestartSystem : IEcsRunSystem
{
    private EcsFilter<EcsUiClickEvent> _filter;
    private RuntimeData _runtimeData;
    public void Run()
    {
        foreach(int i in _filter)
        {
            if (_runtimeData.isGameOver)
                SceneManager.LoadScene(0);
        }
    }

   
}
