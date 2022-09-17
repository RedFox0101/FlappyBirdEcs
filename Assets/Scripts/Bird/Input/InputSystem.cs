using Leopotam.Ecs;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    private EcsFilter<MovableComponent> _filter = null;

    public void Run()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            foreach (var component in _filter)
            {
                Debug.Log("Touch");
                ref var entity = ref _filter.GetEntity(component);
                entity.Get<InputEvent>();
            }
        }
    }
}
