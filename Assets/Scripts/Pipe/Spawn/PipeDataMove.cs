using UnityEngine;

[CreateAssetMenu(fileName ="PipeData")]
public class PipeDataMove:ScriptableObject
{
    public int NumberPipeSpawn;
    public MovablePipeProvider PipePrefab;
    public Transform SpawnPosition;
    public float OffsetX;
    public float MinOffsetY;
    public float MaxOffsetY;
}
