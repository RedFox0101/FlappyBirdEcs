using UnityEngine;

[System.Serializable]
public struct SceneData
{
    public int Number;
    public MovablePipeProvider PipePrefab;
    public Transform SpawnPosition;
    public float OffsetX;
    public float MinOffsetY;
    public float MaxOffsetY;
}
