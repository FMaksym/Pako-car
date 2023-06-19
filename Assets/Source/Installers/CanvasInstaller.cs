using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] private GameUIManager uIManager;

    public override void InstallBindings()
    {
        Container.Bind<GameUIManager>().FromInstance(uIManager).AsSingle();
    }
}