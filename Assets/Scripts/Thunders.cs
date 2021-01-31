using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunders : MonoBehaviour
{
    [SerializeField] private float thunderRateMin = 15f;
    [SerializeField] private float thunderRateMax = 30f;
    [SerializeField] private GameObject thunderObj;

    private void Start()
    {
        ThunderNow();
        Invoke("ThunderNow", GetRandomRate());
    }

    float GetRandomRate()
    {
        return Random.Range(thunderRateMin, thunderRateMax);
    }

    void ThunderNow()
    {
        thunderObj.gameObject.SetActive(true);
        Invoke("EndThunder",5);
        Invoke("ThunderNow", GetRandomRate());
    }

    void EndThunder()
    {
        thunderObj.gameObject.SetActive(false);
    }
}
