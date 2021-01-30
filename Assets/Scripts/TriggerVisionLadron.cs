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
        if (pleier != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, other.transform.position - transform.position,out hit))
            {
                if (hit.collider.gameObject == pleier.gameObject)
                {
                    ladron.AvoidPlayer();
                    pleier.ActivateNavBlock();
                }
            }
        }
    }
}
