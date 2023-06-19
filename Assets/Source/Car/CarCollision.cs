using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public bool IsLose;

    [SerializeField] private EventManager _eventManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() || other.gameObject.GetComponent<Police>())
        {
            if (!IsLose)
            {
                IsLose = true;
                _eventManager.GameOver();
            }
        }
    }
}
