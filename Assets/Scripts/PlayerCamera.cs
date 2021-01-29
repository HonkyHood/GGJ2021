using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target=null;
    [SerializeField] private float smooth = 0.1f;


    private void Update()
    {
        if (target == null)
            return;
        Vector3 vec = target.transform.position;
        vec.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, vec, Time.deltaTime / smooth);
    }
}
