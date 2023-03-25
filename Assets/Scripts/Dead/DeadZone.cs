using Leopotam.Ecs;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BirdView bird))
        {
        
            var enity = EcsStartup.World.NewEntity();
            enity.Get<EventDead>();
        }
    }
}
