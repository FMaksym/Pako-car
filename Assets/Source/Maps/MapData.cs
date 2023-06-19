using UnityEngine;

public class MapData : MonoBehaviour
{
    [Space, Header("Map Config")]
    [SerializeField] private MapConfig _mapConfig;
    
    [Space, Header("Map Status")]
    public bool IsBuy;
    public bool IsSelected;

    public MapConfig MapConfig => _mapConfig;
}