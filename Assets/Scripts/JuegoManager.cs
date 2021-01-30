using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;
    private CuerpoScript s;
    private LadronScript l;

    private void Awake()
    {
        s = GameObject.FindObjectOfType<CuerpoScript>();
        l = GameObject.FindObjectOfType<LadronScript>();
        s.onDead += OnPlayerDeath;
        s.onCatch += OnCatch;
        l.onTakenCoins += OnTakeCoins;
    }

    void OnPlayerDeath(CuerpoScript s)
    {
        GameOver();
    }

    void OnCatch(CuerpoScript s)
    {
        Win();
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
        Invoke("ResetGame", 3);
    }

    void Win()
    {
        s.enabled = false;
        l.enabled = false;
        victoryScreen.SetActive(true);
        Invoke("ResetGame",3);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
