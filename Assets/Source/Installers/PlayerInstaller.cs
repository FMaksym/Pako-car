using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private CoinsAmount coinsAmount;
    [SerializeField] private EarningCoins earningCoins;
    [SerializeField] private GameUIManager uiManager;
    [SerializeField] private InterstitialAdController adController;

    public override void InstallBindings()
    {
        Container.Bind<CoinsAmount>().FromInstance(coinsAmount).AsSingle();
        Container.Bind<EarningCoins>().FromInstance(earningCoins).AsSingle();
        Container.Bind<GameUIManager>().FromInstance(uiManager).AsSingle();
        Container.Bind<InterstitialAdController>().FromInstance(adController).AsSingle();

        var _playerCar = ParameteresForGame._carForGame;
        var playerInstance = Container.InstantiatePrefabForComponent<CarController>(_playerCar, _playerSpawnPoint.position, Quaternion.Euler(0, -90, 0), null);

        Container.Bind<CarController>().FromInstance(playerInstance).AsSingle().NonLazy();
        Container.Bind<CarCollision>().FromInstance(playerInstance.GetComponent<CarCollision>()).AsSingle().NonLazy();
    }
}