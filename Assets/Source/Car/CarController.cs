using UnityEngine;
using Zenject;

public class CarController : MonoBehaviour
{
    public enum ControllType
    {
        Keyboard,
        Mobile
    };

    public ControllType controll;

    public float steerInput;
    public float _moveSpeed = 15f;

    [SerializeField] private float _steerAngle = 20f;
    [SerializeField] private float _drag = 0.95f;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _traction = 1f;
    [SerializeField] private bool IsStearing;
    [SerializeField] private TrailRenderer trailRCircle;
    [SerializeField] private TrailRenderer trailLCircle;

    public float steerSmoothing = 5f;
    private float currentSteerInput;

    private Vector3 moveForce;

    private void Update()
    {
        Move();
        Steering();
        Drag();
        Traction();
    }

    private void Move()
    {
        moveForce += transform.right * _moveSpeed * Time.deltaTime;
        transform.position += moveForce * Time.deltaTime;
        if (steerInput == 0)
        {
            IsStearing = false;
            trailRCircle.emitting = false;
            trailLCircle.emitting = false;
        }
    }

    private void Steering()
    {
        if (controll == ControllType.Keyboard)
        {
            steerInput = Input.GetAxis("Horizontal");
        }
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * _steerAngle * Time.deltaTime);
        if (steerInput > 0 || steerInput < 0)
        {
            IsStearing = true;
            trailRCircle.emitting = true;
            trailLCircle.emitting = true;
        }
    }

    public void CarSteerInput(int inputValue)
    {
       steerInput = inputValue;
    }

    private void Drag()
    {
        moveForce *= _drag;
        moveForce = Vector3.ClampMagnitude(moveForce, _maxSpeed);
    }

    private void Traction()
    {
        moveForce = Vector3.Lerp(moveForce.normalized, transform.right, _traction * Time.deltaTime) * moveForce.magnitude;
    }
}
