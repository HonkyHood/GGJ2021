using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuerpoScript : Personaje
{
    public delegate void CuerpoDelegate(CuerpoScript s);
    public CuerpoDelegate onDead;
    public CuerpoDelegate onHit;
    public CuerpoDelegate onCatch;
    public CuerpoDelegate onChoque;

    [SerializeField] private GameObject particlesPrefab;
    [SerializeField] private float health = 12;
    [SerializeField] private float hurtDuration = 0.5f;
    [SerializeField] private NavMeshObstacle obstacle;
    [SerializeField] private float choqueDefaultDMG=34;
    //[SerializeField] private float choqueDelay = 2f;
    [SerializeField] private float debuffRate = 2f;
    [SerializeField] private float choqueSpeed = 1f;
    [SerializeField] private float choqueDuration = 0.5f;
    private float choqueCur=0f;
    private float choqueMax=100f;
    private bool chocando;
    private bool hurted = false;
    private bool debuffing;

    protected override void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        input.x = -x;
        input.z = -y;
        input.Normalize();
    }

    public float ChoqueCur
    {
        get
        {
            return choqueCur;
        }
    }

    public bool Debuffing
    {
        get
        {
            return debuffing;
        }
    }

    public float ChoqueMax
    {
        get
        {
            return choqueMax;
        }
    }

    public void ActivateNavBlock()
    {
        obstacle.enabled = true;
        CancelInvoke("EndNavBlock");
        Invoke("EndNavBlock", 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        LadronScript l = other.GetComponent<LadronScript>();
        if (l != null)
        {
            onCatch?.Invoke(this);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Chocar(hit);
    }

    void Chocar(ControllerColliderHit hit, float dmg = 0)
    {
        if (hurted)
            return;
        if (dmg <= 0)
            dmg = choqueDefaultDMG;
        Instantiate(particlesPrefab, hit != null ? hit.point : transform.position, Quaternion.identity);
        choqueCur += dmg;
        hurted = true;
        chocando = true;
        Invoke("HurtBack", hurtDuration);
        Invoke("ChoqueEnd", choqueDuration);
        onChoque?.Invoke(this);
        if (choqueCur >= 100)
        {
            debuffing = true;
            choqueCur = 100;
        }
    }

    void ChoqueEnd()
    {
        chocando = false;
    }

    public void TakeDamage (float dmg, ControllerColliderHit hit=null)
    {
        if (hurted)
            return;
        Instantiate(particlesPrefab, hit!=null ? hit.point : transform.position, Quaternion.identity);
        hurted = true;
        health -= dmg;
        if (health <= 0)
        {
            onDead?.Invoke(this);
            return;
        }
        Invoke("HurtBack",hurtDuration);
    }

    void HurtBack()
    {
        hurted = false;
    }

    override protected void CustomUpdate()
    {
        speed = chocando ? 0 : debuffing ? choqueSpeed : defSpeed;
        if (debuffing)
        {
            choqueCur -= Time.deltaTime * debuffRate;
            if (choqueCur <= 0)
            {
                choqueCur = 0;
                debuffing = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void EndNavBlock()
    {
        obstacle.enabled = false;
    }

}
