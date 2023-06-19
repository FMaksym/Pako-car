using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGarageData : MonoBehaviour
{
    [Space, Header("Car Config"), Tooltip("Config containing all information about the Car")]
    [SerializeField] private CarConfig _carConfig;

    [Space, Header("Car Status")]
    public bool IsBuy;
    public bool IsSelected;

    //[Space, Header("Model of car for choise")]
    //public GameObject ModelForSelect;

    public CarConfig CarConfig => _carConfig;
}
