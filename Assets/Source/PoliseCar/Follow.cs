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

        if (Vector3.Distance(transform.position, _carController.transform.position) <= detectionRadius)
        {
            Vector3 targetDirection = _carController.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidDistance, obstacleLayer))
        {
            Vector3 avoidDirection = Vector3.Cross(transform.forward, hit.normal);
            Quaternion avoidRotation = Quaternion.LookRotation(avoidDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, avoidRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
