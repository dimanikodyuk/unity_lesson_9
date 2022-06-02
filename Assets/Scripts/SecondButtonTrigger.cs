using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _colorBlock;
    [SerializeField] private GameObject _imageShoot;

    public static Action changeBallTarget;

    private void OnTriggerEnter(Collider other)
    {
        _colorBlock.GetComponent<Renderer>().material.color = Color.green;
        _imageShoot.SetActive(true);
        changeBallTarget?.Invoke();
    }
}
