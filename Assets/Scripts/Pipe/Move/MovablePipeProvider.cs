using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class MovablePipeProvider : MonoProvider<MovablePipeComponent>
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trigger pipe))
        {
            Entity.Get<TriggerEvent>();
        }
    }
}
