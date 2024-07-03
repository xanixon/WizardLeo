using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using TMPro;
using UnityEngine;

public class UIJoysticControlSystem : IEcsRunSystem
{
    private EcsFilter<EcsUiDragEvent> _dragEvents;
    private EcsFilter<EcsUiBeginDragEvent> _beginDragEvents;
    private EcsFilter<EcsUiEndDragEvent> _endDragEvents;
    private EcsFilter<PlayerInputData> _playerInputData;
    private EcsUiEmitter _emitter;
    private UI _ui;
    private Vector2 _startPosition;
    public void Run()
    {
        float maxDistance = 200;
        foreach (var idx in _beginDragEvents)
        {
            ref EcsUiBeginDragEvent data = ref _beginDragEvents.Get1(idx);            
            _startPosition = _ui.Stick.anchoredPosition / _ui.MainCanvas.scaleFactor;
        }
        foreach (var idx in _dragEvents)
        {
            ref EcsUiDragEvent data = ref _dragEvents.Get1(idx);
            Vector2 delta = data.Delta;
            
            float resultDistance = Vector3.Distance(_ui.Stick.anchoredPosition + delta, _startPosition);
            if (resultDistance < maxDistance)
                _ui.Stick.anchoredPosition += delta;
        }

        foreach (var idx in _endDragEvents)
        {
            ref EcsUiEndDragEvent data = ref _endDragEvents.Get1(idx);
            _ui.Stick.anchoredPosition = new Vector2(0,0);
        }

        foreach(var idx in _playerInputData)
        {
            ref PlayerInputData input = ref _playerInputData.Get1(idx);

            if (maxDistance == 0) continue;

            Vector3 resultInput = new Vector3(_ui.Stick.anchoredPosition.x / maxDistance,
                                              0,
                                              _ui.Stick.anchoredPosition.y / maxDistance);
            input.MoveInput = resultInput.normalized;
        }
    }
}
