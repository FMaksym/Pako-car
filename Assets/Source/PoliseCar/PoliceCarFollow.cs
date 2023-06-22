using UnityEngine;
using Zenject;

public class PoliceCarFollow : MonoBehaviour
{
    [Inject] public CarController _carController;
    [SerializeField] public float followSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetCarController(CarController carController)
    {
        _carController = carController;
    }

    private void FixedUpdate()
    {
        // Calculate direction to the player's car
        Vector3 directionToPlayer = _carController.transform.position - transform.position;
        //directionToPlayer.y = 0f; // Optional: Ensure the police car stays on the same height level

        // Move towards the player's car
        rb.velocity = directionToPlayer.normalized * followSpeed;

        // Rotate the police car to face the player's car
        if (directionToPlayer.magnitude > 0.1f && followSpeed > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, Time.fixedDeltaTime * 200f));
        }
    }
}
