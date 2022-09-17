using UnityEngine;
using Leopotam.Ecs;

public class MoveSysten : IEcsRunSystem
{
    private EcsFilter<MovableComponent, InputEvent> _filter=null;

    public void Run()
    {
        foreach (var component in _filter)
        {
            ref var rigidbody = ref _filter.Get1(component).Rigidbody;
            ref var force = ref _filter.Get1(component).Force;
            Debug.Log(Vector2.up * force);
            rigidbody.velocity = Vector2.up * force;
        }
    }
}
