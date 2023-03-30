using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BirdView bird))
        {        
            var enity = WorldHandler.GetWorld().NewEntity();
            enity.Get<EventDead>();
        }
    }
}
