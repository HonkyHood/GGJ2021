using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private Transform head;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;
    private bool lookIs;

    void Update()
    {
        Test();
    }
    private void Test()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            lookIs = !lookIs;            
        }       

            if (lookIs)
            {
                CamLookAt(head);
            }
            else
            {
                CamLookAt(body);
            }
    }

    public void CamLookAt(Transform _target)
    {
        Vector3 auxPos = _target.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, auxPos, smoothness * Time.deltaTime);
    }
}
