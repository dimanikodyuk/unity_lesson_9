using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private SFXType _ballKick;

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.PlaySFX(_ballKick);
    }
}
