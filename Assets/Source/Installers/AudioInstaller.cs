using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioSource audioSource;

    public override void InstallBindings()
    {
        Container.Bind<AudioSource>().FromInstance(audioSource).AsSingle();
    }
}