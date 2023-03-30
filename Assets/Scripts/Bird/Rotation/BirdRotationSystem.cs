using UnityEngine;
using Leopotam.Ecs;

public class BirdRotationSystem : IEcsRunSystem
{
    private EcsFilter<MovableComponent, RotationComponent> _filter;

    public void Run()
    {
        foreach (var entity in _filter)
        {
            ref var movableComponent = ref _filter.Get1(entity);
            ref var rotationCompanent = ref _filter.Get2(entity);
            ref var transform = ref rotationCompanent.Transform;

            Rotate(ref movableComponent, ref rotationCompanent, ref transform);
        }
    }

    private static void Rotate(ref MovableComponent movableComponent,ref  RotationComponent rotationCompanent,ref  Transform transform)
    {
        Quaternion toRotate;
        if (movableComponent.Rigidbody.velocity.y > 0)
        {
            toRotate = rotationCompanent.topRotation;
        }
        else
        {
            toRotate = rotationCompanent.buttomRotation;
        }
        transform.localRotation = Quaternion.Lerp(transform.rotation, toRotate, rotationCompanent.Speed *Time.deltaTime);
    }
}
