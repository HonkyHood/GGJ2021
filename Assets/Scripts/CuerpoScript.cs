using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuerpoScript : Personaje
{
    public delegate void CuerpoDelegate(CuerpoScript s);
    public CuerpoDelegate onDead;
    public CuerpoDelegate onHit;

    [SerializeField] private GameObject particlesPrefab;
    [SerializeField] private float health = 12;
    [SerializeField] private float hurtDuration = 0.5f;
    [SerializeField] private NavMeshObstacle obstacle;
    private bool hurted = false;

    protected override void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        input.x = x;
        input.z = y;
    }

    public void ActivateNavBlock()
    {
        obstacle.enabled = true;
        CancelInvoke("EndNavBlock");
        Invoke("EndNavBlock", 1f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        TakeDamage(1,hit);
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

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void EndNavBlock()
    {
        obstacle.enabled = false;
    }

}
