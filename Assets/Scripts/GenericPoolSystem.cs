using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class GenericPoolSystem<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;

    [SerializeField]
    private int size;

    public static GenericPoolSystem<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        AddObjects(size);
    }

    public T GetObject()
    {
        return objects.Dequeue();
    }

    private void AddObjects(int queueSize)
    {
        for (int i = 0; i < queueSize; i++)
        {
            var newObject = Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);
        }
    }

    public void ReturnObject(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

}