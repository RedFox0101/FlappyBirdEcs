using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
public class AnimatorDieSystem : IEcsRunSystem
{
    private EcsFilter<AnimatinComponent> _filter;
    private EcsFilter<EventDead> _dieFilter;

    public void Run()
    {
        foreach (var dieEntity in _dieFilter)
        {
            foreach (var entity in _filter)
            {
                ref var component = ref _filter.Get1(entity);
                component.Animator.enabled = false;
            }
        }
    }
}
