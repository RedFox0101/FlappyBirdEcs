using Leopotam.Ecs;
using UnityEngine;

public class InitPipeSystem : IEcsRunSystem
{
    private EcsFilter<MovablePipeComponent> _filter;
    private EcsSystems _system = null;

    public void Run()
    {
        foreach (var component in _filter)
        {
            Debug.Log("Init");
            ref var transform = ref _filter.Get1(component).Transform;
            var pipe = transform.GetComponent<PipeView>();
            ref var pipeEntity = ref _filter.GetEntity(component);
            pipe.SetEntity(pipeEntity);
        }
        var idx = _system.GetNamedRunSystem("Init Pipe");
        _system.SetRunSystemState(idx, false);
    }
}
