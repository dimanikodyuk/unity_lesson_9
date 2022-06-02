using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private FixedJoint _join;
    [SerializeField] private SFXType _catapultSFX;
    private void Start()
    {
        Barrel.onExlode += JoinDestroy;
    }
    private void JoinDestroy()
    {
        Destroy(_join);
        AudioManager.PlaySFX(_catapultSFX);
    }
}
