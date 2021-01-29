using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected CharacterController controller;
    protected Vector3 input;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInput();
        Move();
    }

    protected virtual void GetInput()
    {
        
    }

    protected virtual void Move()
    {
        controller.Move(input * speed * Time.deltaTime);
    }

}
