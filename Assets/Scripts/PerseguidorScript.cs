using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PerseguidorScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] protected AudioClip laughClip;
    protected AudioSource source;
    public delegate void LadronDelegate(LadronScript s);

    protected NavMeshAgent agent;
    public float speed = 2.35f;
    //private LadronState state;

    private void Awake()
    {
        TriggerHurt hurt = GetComponentInChildren<TriggerHurt>();
        source = GetComponent<AudioSource>();
        hurt.onTrigger += OnTrigger;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void OnTrigger ()
    {
        PlayLaugh();
    }

    public void PlayLaugh()
    {
        source.clip = laughClip;
        source.Play();
    }

    private void Update()
    {


        if (target == null)
            return;
        Vector3 dir = target.transform.position - transform.position;
        dir.y = .0f;
        transform.position += dir.normalized * Time.deltaTime * speed;
        transform.LookAt(target.transform);
    }
}
