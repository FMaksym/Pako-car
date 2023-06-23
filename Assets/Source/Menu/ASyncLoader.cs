using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ASyncLoader : MonoBehaviour
{
    [SerializeField] private GameObject _mapCanvas;
    [SerializeField] private GameObject _loadScreen;

    [SerializeField] private Slider slider;

    public void LoadLevelBtn() 
    {
        _mapCanvas.SetActive(false);
        _loadScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(ParameteresForGame._indexOfMapForGame));
    }

    IEnumerator LoadLevelASync(int levelIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelIndex);

        while (!loadOperation.isDone)
        {
            float progressiveValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            slider.value = progressiveValue;
            yield return null;
        }
    }
}
