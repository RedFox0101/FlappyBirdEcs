using Leopotam.Ecs;
using UnityEngine;

public class InitPipeSystem : IEcsRunSystem
{
    private const string KEY_INITSYSTEM = "Init Pipe";

    private EcsFilter<MovablePipeComponent> _filter;
    private EcsSystems _system = null;

    public void Run()
    {
        foreach (var component in _filter)
        {
            ref var transform = ref _filter.Get1(component).Transform;
            var pipe = transform.GetComponent<PipeView>();
            ref var pipeEntity = ref _filter.GetEntity(component);
            pipe.SetEntity(pipeEntity);
        }
        var idx = _system.GetNamedRunSystem(KEY_INITSYSTEM);
        _system.SetRunSystemState(idx, false);
    }
}
