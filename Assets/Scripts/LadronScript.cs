using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LadronScript : MonoBehaviour
{
    public delegate void LadronDelegate(LadronScript s);
    public LadronDelegate onTakenCoins;

    protected NavMeshAgent agent;
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float speedAvoid = 10;
    private List<Monedita> moneditas = new List<Monedita>();
    private int index = 0;
    [SerializeField] private int moneditasToTake = 4;
    //private LadronState state;
    public enum LadronState { Idle, ToGold, Avoiding };

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        moneditas.AddRange(GameObject.FindObjectsOfType<Monedita>());
    }

    private void Start()
    {
        MoveToGold();
    }

    public void AvoidPlayer()
    {
        MoveToGold();
        agent.speed = speedAvoid;
        CancelInvoke("ResetSpeed");
        Invoke("ResetSpeed", 1f);
    }

    void ResetSpeed()
    {
        agent.speed = speed;
    }

    public void TakeCoin(Monedita mon)
    {
        moneditas.Remove(mon);
        Destroy(mon.gameObject);
        moneditasToTake--;
        if (moneditasToTake <= 0)
        {
            //GAMEOVER();
            onTakenCoins?.Invoke(this);
            return;
        }
        MoveToGold();
    }

    void MoveToGold()
    {
        index = Random.Range(0, moneditas.Count);
        agent.SetDestination(moneditas[index].transform.position);
        //state = LadronState.ToGold;
    }
}