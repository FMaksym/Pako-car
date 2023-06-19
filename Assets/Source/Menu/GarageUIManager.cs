using UnityEngine;

public class GarageUIManager : MonoBehaviour
{
    [Space(5)][ Header("Panels")]
    [SerializeField] private GameObject SelectCarPanel;
    [SerializeField] private GameObject SelectCarColorPanel;
    [Space(15)][Header("Canvases")]
    [SerializeField] private GameObject SelectMapCanvas;
    [SerializeField] private GameObject MenuCanvas;

    public void SelectCarToSelectColor()
    {
        SelectCarPanel.SetActive(false);
        SelectCarColorPanel.SetActive(true);
    }
    
    public void SelectColorBackToSelectCar()
    {
        SelectCarColorPanel.SetActive(false);
        SelectCarPanel.SetActive(true);
    }

    public void SelectCarBackToMenu()
    {
        SelectCarPanel.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void SelectColorToSelectMap()
    {
        SelectCarColorPanel.SetActive(false);
        SelectCarPanel.SetActive(true);
    }
}
