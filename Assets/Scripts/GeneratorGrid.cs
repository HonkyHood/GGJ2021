using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorGrid : MonoBehaviour
{
    [SerializeField] private Vector3 sizeCell;
    [SerializeField] private Transform player;
    [SerializeField] int sizeGridX, sizeGridY;
    [SerializeField] private GameObject terrain;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject coin;
    [SerializeField] private Texture2D imageGrid;
    private int[,] gridCreated;

    void Start()
    {
        CreateGridFloor();

        CreateGridObject();


        Starter();
    }

    private void CreateGridFloor()
    {
        gridCreated = new int[sizeGridX, sizeGridY];

        //eje x
        for (int i = 0; i < gridCreated.GetLength(0); i++)
        {
            //eje y
            for (int l = 0; l < gridCreated.GetLength(1); l++)
            { 
                Instantiate(terrain, new Vector3(sizeCell.x * i, 0, sizeCell.z * l), Quaternion.identity);
            }
        }
    }

    private void CreateGridObject()
    {
        //eje x
        for (int i = 0; i < imageGrid.width; i++)
        {
            //eje y
            for (int l = 0; l < imageGrid.height; l++)
            {
                if( imageGrid.GetPixel(i,l).r <= 0)
                {
                    gridCreated[i, l] = 1;
                    Instantiate(wall, new Vector3(sizeCell.x * i, 32, sizeCell.z * l), Quaternion.identity);
                }
                else
                {
                    gridCreated[i, l] = 0;
                }
            }
        }       
    }

   void Starter()
    {       
        player.transform.position = new Vector3(sizeCell.x * 1, 22, sizeCell.z * 1);
    }

  
}
