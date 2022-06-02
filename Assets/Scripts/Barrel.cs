using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private GameObject _partitionFire;
    [SerializeField] private float _time;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private SFXType _barrelSFX;

    [SerializeField] private GameObject _imageShootMe;
    [SerializeField] private GameObject _textTimer;

    private float _timeLeft = 0f;
    public static Action onExlode;

    void Start()
    {
        Shoot.onFire += FireShoot;    
    }

    private void OnDestroy()
    {
        Shoot.onFire -= FireShoot;
    }

    private void FireShoot()
    {
        AudioManager.PlaySFX(_barrelSFX);
        _partitionFire.SetActive(true);
        _imageShootMe.SetActive(false);
        _textTimer.SetActive(true);
        _timeLeft = _time;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            Destroy(gameObject);
            _textTimer.SetActive(false);
            _partitionFire.SetActive(false);
            onExlode?.Invoke();
        }
            
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

}
