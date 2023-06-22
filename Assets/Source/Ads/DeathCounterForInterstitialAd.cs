using System.Collections;
using UnityEngine;
using Zenject;

public class DeathCounterForInterstitialAd : MonoBehaviour
{
    [Inject] private InterstitialAdController interstitialAd;
    private int _deathValue;

    private void Start()
    {
        _deathValue = PlayerPrefs.GetInt("DeathValue");
        if (_deathValue <= 0)
        {
            _deathValue = 5;
            PlayerPrefs.SetInt("DeathValue", _deathValue);
        }
    }

    public void Dead()
    {
        _deathValue -= 1;
        Debug.Log(_deathValue + "death");
        PlayerPrefs.SetInt("DeathValue", _deathValue);
        ShowAd();
    }

    private void ShowAd()
    {
        if (_deathValue <= 0)
        {
            StartCoroutine(WaitAndShowAd());
        }
    }

    private IEnumerator WaitAndShowAd()
    {
        yield return new WaitForSeconds(1);
        interstitialAd.OpenAds();
    }
}
