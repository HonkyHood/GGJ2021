using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected float defSpeed;
    protected CharacterController controller;
    protected Vector3 input;
    protected Vector3 delta;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        defSpeed = speed;
    }

    public float Velocity
    {
        get
        {
            return input.magnitude;
        }
    }

    private void Update()
    {
        GetInput();
        Move();
        CustomUpdate();
    }

    public void AddDelta (Vector3 add)
    {
        delta += add;
    }

    virtual protected void CustomUpdate()
    {

    }

    protected virtual void GetInput()
    {
        
    }

    protected virtual void Move()
    {
        controller.Move(input * speed * Time.deltaTime + delta);
        Vector3 dir = input * speed;
        dir.y = .0f;
        if (dir.magnitude>=.1f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir),Time.deltaTime * 12f);
        delta = Vector3.zero;
    }
}
