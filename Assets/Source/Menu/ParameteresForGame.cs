using UnityEngine;

public class ParameteresForGame : MonoBehaviour
{
    public static GameObject _carForGame;
    public static int _indexOfMapForGame;
    public static string _nameOfMapForGame;

    public void GettingCar(GameObject selectCar)
    {
        _carForGame = selectCar;
    }

    public void GettingMap(string nameOfSelectedMap, int indexOfSelectedMap)
    {
        _nameOfMapForGame = nameOfSelectedMap;
        _indexOfMapForGame = indexOfSelectedMap;
    }
}
