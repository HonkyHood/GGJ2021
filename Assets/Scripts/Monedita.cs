using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedita : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 20*Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        LadronScript s = other.GetComponent<LadronScript>();
        if (s != null)
            s.TakeCoin(this);
    }
}
