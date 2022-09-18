using UnityEngine;
using Leopotam.Ecs;

public class SpawnSystem : MonoBehaviour, IEcsInitSystem
{
    private EcsFilter<SceneData> _filter;

    public void Init()
    {
        foreach (var component in _filter)
        {
            ref var sceneData = ref _filter.Get1(component);
            var spawnPosition = sceneData.SpawnPosition;

            for (int i = 0; i < sceneData.Number; i++)
            {
                spawnPosition.position = GetPosition(sceneData, spawnPosition);
                Instantiate(sceneData.PipePrefab, spawnPosition.position, Quaternion.identity);
            }
        }
    }

    private  Vector2 GetPosition(SceneData sceneData, Transform spawnPosition)
    {
        spawnPosition.position = new Vector2(spawnPosition.position.x, sceneData.SpawnPosition.position.y);
        return new Vector2(spawnPosition.position.x + sceneData.OffsetX, spawnPosition.position.y + Random.Range(sceneData.MinOffsetY, sceneData.MaxOffsetY));   
    }
}
