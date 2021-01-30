using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimator : MonoBehaviour
{
    private LadronScript p;
    private Animator animador;

    private void Awake()
    {
        animador = GetComponent<Animator>();
        p = GetComponentInParent<LadronScript>();
        p.onCoin += OnTakenCoin;
    }

    void OnTakenCoin(LadronScript s)
    {
        animador.SetTrigger("coin");
    }

    private void OnAnimatorMove()
    {
        if (animador == null || p == null)
        {
            return;
        }
        animador.SetFloat("move", p.Velocity);
    }
}
