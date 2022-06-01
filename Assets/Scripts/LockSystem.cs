using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSystem : MonoBehaviour
{
    [SerializeField] FixedJoint _joint;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && _joint != null)
        {
            Debug.Log("START");
            Destroy(_joint);
        }
    }
}
