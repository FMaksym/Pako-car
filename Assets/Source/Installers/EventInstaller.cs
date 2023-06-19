using UnityEngine;
using Zenject;

public class EventInstaller : MonoInstaller
{
    [SerializeField] private EventManager _eventManager;
    public override void InstallBindings()
    {
        var _carEvents = Container.InstantiatePrefabForComponent<EventManager>(_eventManager, Vector3.zero, Quaternion.identity, null);
        Container.Bind<EventManager>().FromInstance(_carEvents).AsSingle().NonLazy();
    }
}