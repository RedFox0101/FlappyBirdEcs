using Leopotam.Ecs;
using UnityEngine;

public class TeleportSystem : IEcsRunSystem
{
    private SceneData _sceneData = null;
    private EcsFilter<MovablePipeComponent, TriggerEvent> _filter;

    public void Run()
    {
        foreach (var component in _filter)
        {
            ref var transform = ref _filter.Get1(component).Transform;
            ref var entity = ref _filter.GetEntity(component);
            transform.position = GetPosition(_sceneData, transform);
            entity.Del<TriggerEvent>();
        }
    }

    private Vector2 GetPosition(SceneData sceneData, Transform spawnPosition)
    {
        spawnPosition.position = sceneData.SpawnPosition.position;
        return new Vector2(spawnPosition.position.x, spawnPosition.position.y + Random.Range(sceneData.MinOffsetY, sceneData.MaxOffsetY));
    }
}
