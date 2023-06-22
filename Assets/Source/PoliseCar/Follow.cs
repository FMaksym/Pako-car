using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Follow : MonoBehaviour
{
    [Inject] public CarController _carController;
    public float speed = 6f;
    public float rotationSpeed = 100f;
    public float detectionRadius = 200f;
    public LayerMask obstacleLayer;
    public float avoidDistance = 50f;

    private Rigidbody rb;

    public void SetCarController(CarController carController)
    {
        _carController = carController;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (_carController == null)
        {
            Debug.LogWarning("Target player is missing!");
            return;
        }

        // Проверяем, находится ли игрок в пределах обнаружения
        if (Vector3.Distance(transform.position, _carController.transform.position) <= detectionRadius)
        {
            // Вычисляем направление к игроку
            Vector3 targetDirection = _carController.transform.position - transform.position;
            //targetDirection.y = 0.1f;

            // Поворачиваем машину в направлении игрока
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Двигаем машину вперед
            rb.velocity = transform.forward * speed;
        }
        else
        {
            // Если игрок не в пределах обнаружения, останавливаем машину
            rb.velocity = Vector3.zero;
        }

        // Проверяем наличие препятствий перед машиной
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidDistance, obstacleLayer))
        {
            // Если обнаружено препятствие, поворачиваем машину в сторону
            Vector3 avoidDirection = Vector3.Cross(transform.forward, hit.normal);
            Quaternion avoidRotation = Quaternion.LookRotation(avoidDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, avoidRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
