using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutRandomizer : MonoBehaviour
{

    public delegate void LayoutDelegate();
    static public LayoutDelegate onPostLayout;
    [SerializeField] private LayoutWorld[] layoutsWorld;
    [SerializeField] private LayoutSpawns[] layoutsSpawn;

    [System.Serializable]
    public class LayoutWorld
    {
        public GameObject[] paredesActivar;
        public GameObject[] paredesDesactivar;

        public void ToggleLayout(bool val)
        {
            for (int i = 0; i < paredesActivar.Length; i++)
            {
                paredesActivar[i].gameObject.SetActive(val);
            }
            for (int i = 0; i < paredesDesactivar.Length; i++)
            {
                paredesActivar[i].gameObject.SetActive(!val);
            }
        }
    }

    [System.Serializable]
    public class LayoutSpawns
    {
        public GameObject[] spawns;

        public void ToggleLayout( bool val)
        {
            for (int i = 0; i < spawns.Length; i++)
            {
                spawns[i].gameObject.SetActive(val);
            }
        }
    }

    private void Awake()
    {
        int world = Random.Range(0, layoutsWorld.Length);
        int spawn = Random.Range(0, layoutsSpawn.Length);

        for (int i = 0; i < layoutsWorld.Length; i++)
        {
            layoutsWorld[i].ToggleLayout(false);
        }
        layoutsWorld[world].ToggleLayout(true);

        for (int i = 0; i < layoutsSpawn.Length; i++)
        {
            layoutsSpawn[i].ToggleLayout(false);
        }
        layoutsSpawn[spawn].ToggleLayout(true);
        onPostLayout?.Invoke();
    }
}
