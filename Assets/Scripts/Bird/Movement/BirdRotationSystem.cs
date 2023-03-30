using UnityEngine;
using Leopotam.Ecs;

public class BirdRotationSystem : IEcsRunSystem
{
    private EcsFilter<MovableComponent> _filter;
    private Quaternion _topRotation =  Quaternion.Euler(new Vector3(0, 0, 15));
    private Quaternion _bottomRotation = Quaternion.Euler(new Vector3(0, 0, -15));
    public void Run()
    {
        foreach (var entity in _filter)
        {
            ref var movableComponent = ref _filter.Get1(entity);
            if (movableComponent.Rigidbody.velocity.y > 0)
            {
                movableComponent.Rigidbody.transform.localRotation = _topRotation;
            }
            else
            {
                movableComponent.Rigidbody.transform.localRotation = _bottomRotation;
            }
        }
    }
}
