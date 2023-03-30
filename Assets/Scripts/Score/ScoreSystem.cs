using Leopotam.Ecs;
public class ScoreSystem : IEcsRunSystem
{
    private ScoreView _scoreView = null;
    private EcsFilter<EventPassedPipe> _filter;
    public void Run()
    {
        foreach (var eventPipe in _filter)
        {
            _scoreView.AddScore();
            ref var entity = ref _filter.GetEntity(eventPipe);
            entity.Del<EventPassedPipe>();
        }
    }
}
