using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PerseguidorScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    public delegate void LadronDelegate(LadronScript s);

    protected NavMeshAgent agent;
    [SerializeField] protected float speed = 2.35f;
    //private LadronState state;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.transform.position - transform.position;
        dir.y = .0f;
        transform.position += dir.normalized * Time.deltaTime * speed;
    }
}
