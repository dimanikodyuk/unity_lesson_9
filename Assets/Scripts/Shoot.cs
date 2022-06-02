using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private AutoDestroy _impactPrefab;
    private Ray _ray;
    private RaycastHit _raycastHit;

    public static Action onFire;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootMethod();
        }
    }

    private void ShootMethod()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _raycastHit))
        {
            if (_raycastHit.transform.name == "barrel")
            {
                onFire?.Invoke();
            }

            CreateShootImpact(_raycastHit.point);
        }
    }

    private void CreateShootImpact(Vector3 position)
    {
        Instantiate(_impactPrefab, position, Quaternion.identity);
    }
}
