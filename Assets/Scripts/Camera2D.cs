using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    
    [SerializeField] private string _playerTag;
    [SerializeField] private float _speedMove;
    [SerializeField] private Transform _firstBall;
    [SerializeField] private Transform _secondBall;
    [SerializeField] private Transform _thirdBall;
    [SerializeField] private int _distance;

    private void Awake()
    {
        ButtonTrigger.changeTarget += ChangeSecondTrigger;
        SecondButtonTrigger.changeBallTarget += ChangeThirdTrigger;
    }

    private void OnDestroy()
    {
        ButtonTrigger.changeTarget -= ChangeSecondTrigger;
        SecondButtonTrigger.changeBallTarget -= ChangeThirdTrigger;
    }


    private void ChangeSecondTrigger()
    {
        _firstBall = _secondBall.transform; 
    }

    private void ChangeThirdTrigger()
    {
        _firstBall = _thirdBall.transform;
    }

    private void Update()
    {
        if (_firstBall)
        {
            Vector3 target = new Vector3()
            {
                x = _firstBall.position.x + _distance,
                y = _firstBall.position.y + 2,
                z = _firstBall.position.z - 2
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, _speedMove * Time.deltaTime);
            transform.position = pos;
        }
    }

}
