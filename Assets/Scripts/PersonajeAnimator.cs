using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimator : MonoBehaviour
{
    private CuerpoScript p;
    private Animator animador;

    private void Awake()
    {
        animador = GetComponent<Animator>();
        p = GetComponentInParent<CuerpoScript>();
        p.onChoque += OnChoque;
    }

    void OnChoque(CuerpoScript s)
    {
        animador.SetTrigger("choque");
    }

    private void OnAnimatorMove()
    {
        if (animador == null || p == null)
        {
            return;
        }
        p.AddDelta(animador.deltaPosition);
        animador.SetFloat("move", p.Velocity);
    }
}
