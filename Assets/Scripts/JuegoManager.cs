using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private AudioClip loseGoblin;
    [SerializeField] private AudioClip loseGhost;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioSource music;
    private AudioSource source;
    private CuerpoScript s;
    private LadronScript l;
    private PerseguidorScript p;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
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
        source.clip = loseGhost;
        source.Play();
        GameOver();
    }

    void OnCatch(CuerpoScript s)
    {
        source.clip = win;
        source.Play();
        Win();
    }

    void OnTakeCoins(LadronScript l)
    {
        source.clip = loseGoblin;
        source.Play();
        GameOver();
    }

    void GameOver()
    {
        music.volume = 0;
        Time.timeScale = 0;
        endGameUI.SetActive(true);
        s.enabled = false;
        l.enabled = false;
        gameOverScreen.SetActive(true);
        //Invoke("ResetGame", 3);
    }

    void Win()
    {
        music.volume = 0;
        Time.timeScale = 0;
        endGameUI.SetActive(true);
        s.enabled = false;
        l.enabled = false;
        victoryScreen.SetActive(true);
        //Invoke("ResetGame",3);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
