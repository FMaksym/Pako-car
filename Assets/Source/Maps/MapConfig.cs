using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Map", fileName = "MapConfig", order = 1)]
public class MapConfig : ScriptableObject
{
    [Space(5), Header("Map Name")]
    [SerializeField] private string _mapName;
    [Space(5), Header("Price")]
    [SerializeField, Min(1000)] private int _price;
    [Space(5), Header("Map Index")]
    [SerializeField, Min(2)] private int _mapIndex;

    public string MapName => _mapName;
    public int Price => _price;
    public int MapIndex => _mapIndex;
}
