using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInitial : MonoBehaviour
{

    [Header("Characters")]
    [SerializeField] private Transform skeleton;
    [SerializeField] private Transform goblin;
    [SerializeField] private Transform ghost;

    [Header("Spawn Positions from Options")]
    [SerializeField] private OptionsSpawn[] options;
    [SerializeField] private int posSelected;
    [SerializeField] private InitialCamera cam;

    private void Awake()
    {
        SetPosition();        
    }




    public int RamdomOptions()
    {
        int r = Random.Range(0, 8);       
        return r;
    }

    public void SetPosition()
    {
        //posSelected = RamdomOptions();
        skeleton.GetComponent<CharacterController>().enabled = false;
        skeleton.position = options[0].pointsSpawns[posSelected].position;
        goblin.position = options[1].pointsSpawns[posSelected].position;
        ghost.position = options[2].pointsSpawns[posSelected].position;
        skeleton.GetComponent<CharacterController>().enabled = true;

        cam.SetInitalPosCamera(skeleton.position);
    }


   
}


[System.Serializable]
public class OptionsSpawn
{
    public Transform[] pointsSpawns;
}