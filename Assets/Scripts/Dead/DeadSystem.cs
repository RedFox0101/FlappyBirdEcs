using Leopotam.Ecs;

public class DeadSystem : IEcsRunSystem
{
    private EcsFilter<EventDead> _filter;
    private EcsFilter<MovablePipeComponent> _pipeFilter;
    private EcsFilter<MovableComponent> _birdFilter;
    private EcsFilter<AnimatinComponent> _animationFilter;

    public void Run()
    {
        foreach (var entity in _filter)
        {
            foreach(var pipeEntity in _pipeFilter)
            {
                ref var newEntity = ref _pipeFilter.GetEntity(pipeEntity);
                newEntity.Get<TerminationComponent>();
            }
            foreach (var birdEntity in _birdFilter)
            {
                ref var newEntity = ref _birdFilter.GetEntity(birdEntity);
                newEntity.Get<TerminationComponent>();
            }
            foreach (var animator in _animationFilter)
            {
                ref var animatorComponent = ref _animationFilter.Get1(animator);
                animatorComponent.Animator.enabled = false;
            }
        }
    }
}
