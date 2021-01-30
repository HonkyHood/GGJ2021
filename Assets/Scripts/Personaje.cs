using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected float defSpeed;
    protected CharacterController controller;
    protected Vector3 input;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        defSpeed = speed;
    }

    private void Update()
    {
        GetInput();
        Move();
        CustomUpdate();
    }

    virtual protected void CustomUpdate()
    {

    }

    protected virtual void GetInput()
    {
        
    }

    protected virtual void Move()
    {
        controller.Move(input * speed * Time.deltaTime);
    }

}
