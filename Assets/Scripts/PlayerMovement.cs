using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 direction;

    private CharacterController playerCC;

    private void Start()
    {
        playerCC = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ReadInput();
        Move();
    }

    private void ReadInput()
    {   
        if (Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(0, 0, 1);
        }

        else if (Input.GetKey(KeyCode.S))
        {
                direction = new Vector3(0, 0, -1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            direction = new Vector3(-1, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
                direction = new Vector3(1, 0, 0);
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    private void Move()
    {
        playerCC.Move(direction * speed * Time.deltaTime);
    }
}
