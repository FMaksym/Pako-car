using System.Collections;
using UnityEngine;

public class PoliceObstacle : MonoBehaviour
{
    public PoliceCarFollow policeCar;
    [SerializeField] private GameObject _explosionParticle;

    private void Start()
    {
        policeCar = GetComponent<PoliceCarFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() || other.gameObject.GetComponent<CarController>() || other.gameObject.GetComponent<Police>())
        {
            policeCar.followSpeed = 0f;
            _explosionParticle.SetActive(true);
            StartCoroutine(WaitAndDestroy(2));
        }
    }

    IEnumerator WaitAndDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
