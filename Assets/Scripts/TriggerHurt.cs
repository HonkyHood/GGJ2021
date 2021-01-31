using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHurt : MonoBehaviour
{

    public delegate void TriggerDelegate();
    public TriggerDelegate onTrigger;

    private void OnTriggerStay(Collider other)
    {
        CuerpoScript pleier = other.GetComponent<CuerpoScript>();
        if (other.CompareTag("Player"))
        {
            if (pleier.TakeDamage(1))
                onTrigger?.Invoke();
        }
    }
}
