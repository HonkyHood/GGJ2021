using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    private CuerpoScript s;
    private LadronScript l;

    private void Awake()
    {
        s = GameObject.FindObjectOfType<CuerpoScript>();
        l = GameObject.FindObjectOfType<LadronScript>();
        s.onDead += OnPlayerDeath;
        l.onTakenCoins += OnTakeCoins;
    }

    void OnPlayerDeath(CuerpoScript s)
    {
        GameOver();
    }

    void OnTakeCoins(LadronScript l)
    {
        GameOver();
    }

    void GameOver()
    {
        s.enabled = false;
        l.enabled = false;
        gameOverScreen.SetActive(true);
    }
}
