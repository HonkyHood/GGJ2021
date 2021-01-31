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
    private PerseguidorScript p;

    private void Awake()
    {
        LayoutRandomizer.onPostLayout += OnPostLayout;
        s = GameObject.FindObjectOfType<CuerpoScript>();
        l = GameObject.FindObjectOfType<LadronScript>();
        p = GameObject.FindObjectOfType<PerseguidorScript>();
        s.onDead += OnPlayerDeath;
        s.onCatch += OnCatch;
        l.onTakenCoins += OnTakeCoins;
    }

    void OnPostLayout()
    {
        TeleportCharacters();
    }

    void TeleportCharacters()
    {
        s.transform.position = GameObject.FindWithTag("SpawnPlayer").transform.position;
        l.transform.position = GameObject.FindWithTag("SpawnLadron").transform.position;
        p.transform.position = GameObject.FindWithTag("SpawnGhost").transform.position;
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
