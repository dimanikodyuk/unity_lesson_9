using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    
    [SerializeField] private string _playerTag;
    [SerializeField] private float _speedMove;
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private Transform _secondBall;
    [SerializeField] private int _distance;

    private void Awake()
    {
        ButtonTrigger.changeTarget += ChangeTrigger;
    }

    private void OnDestroy()
    {
        ButtonTrigger.changeTarget -= ChangeTrigger;
    }

    private void ChangeTrigger()
    {
        _ballTransform = _secondBall.transform;
    }

    private void Update()
    {
        if (_ballTransform)
        {
            Vector3 target = new Vector3()
            {
                x = _ballTransform.position.x + _distance,
                y = _ballTransform.position.y + 2,
                z = _ballTransform.position.z - 2
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, _speedMove * Time.deltaTime);
            transform.position = pos;
        }
    }

}
