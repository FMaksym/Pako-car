using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SteerButtons : MonoBehaviour
{
    [SerializeField] private EventTrigger L_button;
    [SerializeField] private EventTrigger R_button;

    [Inject]
    [SerializeField] private CarController _car;

    public void TurnRight()
    {
        _car.CarSteerInput(1);
    }

    public void TurnLeft()
    {
        _car.CarSteerInput(-1);
    }

    public void GoStraight()
    {
        _car.CarSteerInput(0);
    }
}
