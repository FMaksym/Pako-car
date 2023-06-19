using UnityEngine;
using Zenject;

public class PoliceCarInstaller : MonoInstaller
{
    public GameObject policeCarPrefab;
    public override void InstallBindings()
    {
        Container.Bind<PoliceCarSpawner>().AsSingle();
    }
}