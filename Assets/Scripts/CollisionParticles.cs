using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionParticles : MonoBehaviour
{ 
    [SerializeField]
    private float lifeSpan;

    private float timeRemaining = 0;

    private void Update()
    {
        timeRemaining += Time.deltaTime;

        if (timeRemaining >= lifeSpan)
        {
            ParticleDeath();
        }
    }

    public void ParticleDeath()
    {
        ParticulasPool.Instance.ReturnObject(this);
    }

}