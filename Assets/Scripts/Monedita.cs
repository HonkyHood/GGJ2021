using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedita : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LadronScript s = other.GetComponent<LadronScript>();
        if (s != null)
            s.TakeCoin(this);
    }
}
