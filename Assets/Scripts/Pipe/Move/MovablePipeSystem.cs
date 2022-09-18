using UnityEngine;
using Leopotam.Ecs;

public class MovablePipeSystem : IEcsRunSystem
{
    private EcsFilter<MovablePipeComponent> _filter;

    public void Run()
    {
        foreach (var component in _filter)
        {
            ref var transform = ref _filter.Get1(component).Transform;
            ref var speed = ref _filter.Get1(component).Speed;

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
