using UnityEngine;
using Zenject;

public class DiContainerInstaller : MonoInstaller
{
    [Inject] private DiContainer diContainer;
    public override void InstallBindings()
    {
        DiContainerRef.Container = Container;
    }
}