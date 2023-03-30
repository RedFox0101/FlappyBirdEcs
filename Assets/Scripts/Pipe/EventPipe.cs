using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class EventPipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        var newEnity = WorldHandler.GetWorld().NewEntity();
        newEnity.Get<EventPassedPipe>();
    }
}
