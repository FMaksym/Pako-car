using System.Collections;
using UnityEngine;
using Zenject;

public class PoliceObstacle : MonoBehaviour
{
    public Follow policeCar;

    [Inject] private AudioSource audioSource;

    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private GameObject _explosionParticle;

    private void Start()
    {
        policeCar = GetComponent<Follow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() || other.gameObject.GetComponent<CarController>() || other.gameObject.GetComponent<Police>())
        {
            //policeCar.followSpeed = 0f;
            policeCar.speed = 0f;
            PlayDestroySound();
            _explosionParticle.SetActive(true);
            StartCoroutine(WaitAndDestroy(1));
        }
    }

    IEnumerator WaitAndDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void PlayDestroySound()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = _destroySound;
        audioSource.Play();
        audioSource.volume = 1f;
    }
}
