using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCamera : MonoBehaviour
{
    [SerializeField] private Transform finalPos;

    [SerializeField] private float smooth = 0.8f;


    private void Update()
    {
        if (finalPos == null)
            return;

        transform.position = Vector3.Lerp(transform.position, finalPos.position, smooth*Time.deltaTime);
    }

    public void SetInitalPosCamera(Vector3 _target)
    {
        Vector3 auxPos = _target + new Vector3(0, 2, 0); 
        transform.position = auxPos;
    }


    public void SetEndPosCamera(Transform _target)
    {
        Vector3 auxPos = _target.position + new Vector3(0, 2.5f, 0);
      
        transform.position = Vector3.Lerp(transform.position, auxPos, smooth * Time.deltaTime);
    }


}
