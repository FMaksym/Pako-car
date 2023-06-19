using UnityEngine;
using Zenject;

public sealed class MenuCanvasesInstaller : MonoInstaller
{
    [SerializeField] private SelectColorOfCarUI selectColorOfCarUIManager;
    [SerializeField] private SelectCarUI selectCarUIManager;

    public override void InstallBindings()
    {
        Container.Bind<ICanvas>().To<SelectCarUI>().AsSingle();
        Container.Bind<ICanvas>().To<SelectColorOfCarUI>().AsSingle();
        //Container.Bind<ICanvas>().To<SelectColorOfCarUIManager>().AsSingle();
    }
}