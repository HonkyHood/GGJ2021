using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationZero : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
