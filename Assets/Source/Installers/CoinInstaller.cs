using UnityEngine;
using Zenject;

public class CoinInstaller : MonoInstaller
{
    [SerializeField] private CoinsAmount coinsAmount;

    public override void InstallBindings()
    {
        Container.Bind<CoinsAmount>().FromInstance(coinsAmount).AsSingle();
    }
}