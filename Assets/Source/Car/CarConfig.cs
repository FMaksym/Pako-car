using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Car", fileName = "CarConfig", order = 0)]
public class CarConfig : ScriptableObject
{
    [Header("Name")]
    [SerializeField] private string _carName;

    [Header("Common")]
    [Header("Price")]
    [SerializeField] private int _price;
    [Header("Car Speed")]
    [SerializeField, Min(0)] private float _speed;
    [Header("Car Steer")]
    [SerializeField, Min(0)] private float _steer;

    public string Name => _carName;
    public int Price => _price;
    public float Speed => _speed;
    public float Steer => _steer;
}
