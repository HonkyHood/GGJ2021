using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionOsci : MonoBehaviour
{
    [SerializeField] private float mult = 1f;
    [SerializeField] private float time = 0.5f;
    private float t = 0;

    private void Update()
    {
        t += Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, Mathf.Sin(Mathf.PI * t * time) * mult,0);
    }
}
