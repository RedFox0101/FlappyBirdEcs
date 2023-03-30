using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BirdView bird))
            Die();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BirdView bird))
            Die();

    }

    private static void Die()
    {
        var enity = WorldHandler.GetWorld().NewEntity();
        enity.Get<EventDead>();
    }

}
