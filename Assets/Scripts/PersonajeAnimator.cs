using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimator : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private CuerpoScript p;
    private Animator animador;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponentInParent<AudioSource>();
        animador = GetComponent<Animator>();
        p = GetComponentInParent<CuerpoScript>();
        p.onChoque += OnChoque;
    }

    public void PlayFootstep()
    {
        int rdm = Random.Range(0, clips.Length);
        source.clip = clips[rdm];
        source.Play();
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
