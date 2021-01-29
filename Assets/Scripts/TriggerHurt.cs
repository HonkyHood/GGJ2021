using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHurt : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        CuerpoScript pleier = other.GetComponent<CuerpoScript>();
        if (other.CompareTag("Player"))
        {
            pleier.TakeDamage(1);
        }
    }
}
