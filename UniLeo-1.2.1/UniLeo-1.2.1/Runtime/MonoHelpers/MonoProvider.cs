using Leopotam.Ecs;
using UnityEngine;
using System.Collections.Generic;

namespace Voody.UniLeo
{
    public abstract class MonoProvider<T> : BaseMonoProvider, IConvertToEntity where T : struct
    {
        [SerializeField]
        protected T value;

        public EcsEntity Entity { get; private set; }

        void IConvertToEntity.Convert(EcsEntity entity)
        {
            Entity = entity;
            entity.Replace(value);
        }
    }
}
