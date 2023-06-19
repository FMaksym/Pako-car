using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Zenject;
using PlayerPrefs = PlayerPrefsWrapper;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public TMP_Text TimeText;

    private int _stage = 1;
    private float _timeForStage = 30f;
    private float _elapsedTime;
    private float _stageTimeValue;
    private float _recordTime;
    private bool _timeGoing;
    private string _recordTimeStr;
    private string timePlayingStr;
    private TimeSpan _timePlaying;

    [Inject] private EarningCoins earningCoins;
    [Inject] private CarCollision carCollision;

    private void Awake()
    {
        instance = this;
        _recordTime = PlayerPrefs.GetFloat("RecordTimeInSeconds");
        _recordTimeStr = PlayerPrefs.GetString("RecordTimeStr");
    }

    private void Start()
    {
        TimeText.text = "00:00:00.00";
        _timeGoing = false;

        BeginTimer();
    }

    public void BeginTimer()
    {
        _timeGoing = true;
        var startTime = Time.time;
        _elapsedTime = 0f;

        StartCoroutine(UpdateTime());
    }

    public void EndTime()
    {
        _timeGoing = false;
        float gameTime = _elapsedTime;
        earningCoins.AddCoinsFromTime(gameTime);
        if (gameTime > _recordTime)
        {
            PlayerPrefs.SetFloat("RecordTimeInSeconds", gameTime);
            PlayerPrefs.SetString("RecordTimeStr", timePlayingStr);
        }
    }

    private IEnumerator UpdateTime()
    {
        while (_timeGoing)
        {
            _elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            timePlayingStr = _timePlaying.ToString("hh\\:mm\\:ss\\.ff");
            TimeText.text = timePlayingStr;
            StageTime();

            if (carCollision.IsLose)
            {
                EndTime();
            }
            yield return null;
        }
    }

    private void StageTime()
    {
        _stageTimeValue += Time.deltaTime;
        if (_stageTimeValue >= _timeForStage)
        {
            earningCoins.AddCoinsPerStage(_stage);
            _stage++;
            _stageTimeValue = 0;
        }
    }
}
