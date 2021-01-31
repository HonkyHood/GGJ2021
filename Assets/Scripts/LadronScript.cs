using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LadronScript : MonoBehaviour
{
    public delegate void LadronDelegate(LadronScript s);
    public LadronDelegate onTakenCoins;
    public LadronDelegate onCoin;

    protected NavMeshAgent agent;
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float speedAvoid = 10;
    [SerializeField] protected float distanceHear = 10f;
    [SerializeField] protected GameObject exclamation;
    [SerializeField] protected GameObject interrogation;
    [SerializeField] protected float takeCoinDuration = 1f;
    [SerializeField] protected AudioClip coinClip;
    [SerializeField] protected AudioClip haaaClip;
    protected AudioSource source;
    private List<Monedita> moneditas = new List<Monedita>();
    private int index = 0;
    private bool checking;
    [SerializeField] private int moneditasToTake = 4;
    //private LadronState state;
    public enum LadronState { Idle, ToGold, Avoiding };

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        moneditas.AddRange(GameObject.FindObjectsOfType<Monedita>());
        GameObject.FindObjectOfType<CuerpoScript>().onChoque += OnChoque;
    }


    public float Velocity
    {
        get
        {
            return agent.desiredVelocity.magnitude;
        }
    }

    void OnChoque(CuerpoScript s)
    {
        if (!checking && Vector3.Distance(s.transform.position,transform.position) <= distanceHear)
        {
            AvoidPlayer();
            //StartCoroutine("SoundCheck", s.transform.position);
        }
    }

    IEnumerator SoundCheck (Vector3 origin)
    {
        Debug.Log("ASD");
        checking = true;
        float t = 0f;
        agent.speed = 0;
        agent.isStopped = true;
        interrogation.gameObject.SetActive(true);
        while (t < 1)
        {
            t += Time.deltaTime / 1f;
            yield return null;
        }
        t = 0;
        Vector3 dir = origin - transform.position;
        dir.y = .0f;
        while (t < 1)
        {
            t += Time.deltaTime / 3f;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(dir), t * 5);
            yield return null;
        }
        interrogation.gameObject.SetActive(false);
        agent.speed = speed;
        agent.isStopped = false;
        checking = false;
        Debug.Log("END");
    }

    private void Start()
    {
        MoveToGold();
    }

    public void AvoidPlayer()
    {
        MoveToGold();
        StopAllCoroutines();
        source.clip = haaaClip;
        source.Play();
        interrogation.gameObject.SetActive(false);
        exclamation.gameObject.SetActive(true);
        agent.isStopped = false;
        checking = false;
        agent.speed = speedAvoid;
        CancelInvoke("ResetSpeed");
        Invoke("ResetSpeed", 1f);
    }

    void ResetSpeed()
    {
        exclamation.gameObject.SetActive(false);
        agent.speed = speed;
    }

    public void TakeCoin(Monedita mon)
    {
        moneditas.Remove(mon);
        source.clip = coinClip;
        source.Play();
        Destroy(mon.gameObject);
        moneditasToTake--;
        onCoin?.Invoke(this);
        if (moneditasToTake <= 0)
        {
            //GAMEOVER();
            onTakenCoins?.Invoke(this);
            return;
        }
        agent.speed = 0;
        Invoke("MoveToGold", takeCoinDuration);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceHear);

        if (true)
            return;

        if (agent == null)
            return;

        Gizmos.color = Color.blue;
        for (int i = 0; i < agent.path.corners.Length-1; i++)
        {
            Vector3 startPos = transform.position;
            if (i > 0)
                startPos = agent.path.corners[i];
            Gizmos.DrawLine(startPos, agent.path.corners[i + 1]);
        }
    }

    void MoveToGold()
    {
        agent.speed = speed;
        index = Random.Range(0, moneditas.Count);
        agent.SetDestination(moneditas[index].transform.position);
        //state = LadronState.ToGold;
    }
}