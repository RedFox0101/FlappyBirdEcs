using Leopotam.Ecs;
using UnityEngine;

public class PipeView : MonoBehaviour
{
    private EcsEntity _entity;

    public void SetEntity(EcsEntity entity)
    {
        _entity = entity;
    }

    private void OnCollision()
    {
        _entity.Get<TriggerEvent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trigger pipe))
        {
            OnCollision();
        }
    }
}
