using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoliceCarSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private GameObject policeCarPrefab;

    public float TimeToSpawn;

    private Coroutine spawnCoroutine;

    private CarController carController;
    private CarCollision carCollision;
    private DiContainer container;

    [Inject]
    public void Construct(CarController carController, CarCollision carCollision, DiContainer container)
    {
        this.carController = carController;
        this.carCollision = carCollision;
        this.container = container;
    }

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnPoliceCars());
        TimeToSpawn = 2;
    }

    private IEnumerator SpawnPoliceCars()
    {
        while (!carCollision.IsLose)
        {
            yield return new WaitForSeconds(TimeToSpawn);

            if (_spawnPoints.Count > 0)
            {
                int randomIndex = Random.Range(0, _spawnPoints.Count);
                Transform spawnPoint = _spawnPoints[randomIndex];

                container.InstantiatePrefab(policeCarPrefab, spawnPoint.position, spawnPoint.rotation, parentTransform)
                     .GetComponent<Follow>()
                     .SetCarController(carController);
            }
        }
    }
}
