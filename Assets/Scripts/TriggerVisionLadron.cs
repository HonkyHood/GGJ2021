using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVisionLadron : MonoBehaviour
{

    private LadronScript ladron;

    private void Awake()
    {
        ladron = GetComponentInParent<LadronScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        CuerpoScript pleier = other.GetComponent<CuerpoScript>();
        if (other.CompareTag("Player"))
        {
            ladron.AvoidPlayer();
            pleier.ActivateNavBlock();
        }
    }
}
