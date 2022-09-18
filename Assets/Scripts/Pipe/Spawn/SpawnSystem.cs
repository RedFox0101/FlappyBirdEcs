using UnityEngine;
using Leopotam.Ecs;

public class SpawnSystem : MonoBehaviour, IEcsInitSystem
{
    private SceneData _sceneData=null;

    public void Init()
    {
        var spawnPosition = _sceneData.SpawnPosition.position;

        for (int i = 0; i < _sceneData.Number; i++)
        {
            spawnPosition = GetPosition(_sceneData, spawnPosition);
            Instantiate(_sceneData.PipePrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetPosition(SceneData sceneData, Vector3 spawnPosition)
    {
        spawnPosition = new Vector2(spawnPosition.x, sceneData.SpawnPosition.position.y);
        return new Vector2(spawnPosition.x + sceneData.OffsetX, spawnPosition.y + Random.Range(sceneData.MinOffsetY, sceneData.MaxOffsetY));
    }
}
