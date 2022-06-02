using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    [SerializeField] private float _time;
    [SerializeField] private TMP_Text _timerText;

    [SerializeField] private SFXType _exlodeSFX;

    private float _timeLeft = 0f;

    public void ExplodeBurret()
    {
        AudioManager.PlaySFX(_exlodeSFX);

        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _explodeRadius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_explodeForce, transform.position, _explodeRadius);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            _timeLeft = _time;
            StartCoroutine(StartTimer());
        }
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
            _timerText.text = "";
            _timeLeft = 0;
            ExplodeBurret();
            Destroy(gameObject);
        }

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }


}
