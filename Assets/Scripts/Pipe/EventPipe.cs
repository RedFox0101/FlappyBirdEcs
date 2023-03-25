using UnityEngine;
using Leopotam.Ecs;
public class EventPipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("D");

        var newEnity = EcsStartup.World.NewEntity();
        newEnity.Get<EventPassedPipe>();

    }
}
