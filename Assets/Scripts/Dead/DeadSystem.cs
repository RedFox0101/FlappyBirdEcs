using Leopotam.Ecs;

public class DeadSystem : IEcsRunSystem
{
    private ScoreView _scoreView = null;
    private EcsFilter<EventDead> _filter;
    private EcsFilter<MovablePipeComponent> _pipeFilter;
    private EcsFilter<MovableComponent> _birdFilter;

    public void Run()
    {
        foreach (var entity in _filter)
        {
            _scoreView.DeactivareScoreElements();
            AddComponent(_pipeFilter);
            AddComponent(_birdFilter);
        }
    }

    private void AddComponent(EcsFilter filter)
    {
        foreach (var entity in filter)
        {
            ref var newEntity = ref filter.GetEntity(entity);
            newEntity.Get<TerminationComponent>();
        }
    }
}
