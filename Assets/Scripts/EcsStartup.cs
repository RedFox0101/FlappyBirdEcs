using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

sealed class EcsStartup : MonoBehaviour
{
    [SerializeField] private PipeDataMove _sceneData;
    [SerializeField] private ScoreView _scoreView;

    private const string KEY_INITSYSTEM = "Init Pipe";

    private  EcsWorld _world;
    private EcsSystems _systems;

    void Start()
    {
        InitEcs();
        AddSystem();
        AddOneFrameComponent();
        _systems.Init();
    }

    private void InitEcs()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.ConvertScene();
        InjectFields();

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
    }

    private void InjectFields()
    {
        _systems.Inject(_sceneData);
        _systems.Inject(_systems);
        _systems.Inject(_scoreView);
    }

    private void AddSystem()
    {
        _systems.
            Add(new SpawnSystem()).
            Add(new MovablePipeSystem()).
            Add(new InitPipeSystem(), KEY_INITSYSTEM).
            Add(new TeleportSystem()).
            Add(new InputSystem()).
            Add(new MoveSysten()).
            Add(new BirdRotationSystem()).
            Add(new ScoreSystem()).
            Add(new DeadSystem()).
            Add(new AnimatorDieSystem());
             
    }

    private void AddOneFrameComponent()
    {
        _systems.OneFrame<InputEvent>();
    }

    void Update()
    {
        _systems?.Run();
    }

    void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}
