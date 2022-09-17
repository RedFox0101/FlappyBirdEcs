using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

sealed class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
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
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
    }

    private void AddSystem()
    {
        _systems.Add(new InputSystem()).
            Add(new MoveSysten());
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
