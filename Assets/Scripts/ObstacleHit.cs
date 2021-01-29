using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    private GameObject playerGO;

    private void Start()
    {
        playerGO = GameObject.Find("Player");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El player choca con el muro");

            var newParticle =  ParticulasPool.Instance.GetObject();

            newParticle.gameObject.SetActive(true);

            newParticle.transform.position = playerGO.transform.position;
        }
    }
}
