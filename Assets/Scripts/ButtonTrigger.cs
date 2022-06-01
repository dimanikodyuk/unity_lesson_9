using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _desroyablePlatform;
    public static Action changeTarget;

    private void OnTriggerEnter(Collider other)
    {
        changeTarget?.Invoke();
        Destroy(_desroyablePlatform);
    }
}
