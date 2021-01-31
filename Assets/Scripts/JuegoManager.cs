using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuegoManager : MonoBehaviour
{

    public static JuegoManager intance;
    [SerializeField] private GameObject starter;
    [SerializeField] private InitialCamera cam;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private AudioClip loseGoblin;
    [SerializeField] private AudioClip loseGhost;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioSource music;
    private AudioSource source;
    private CuerpoScript playerSkeleton;
    private LadronScript goblin;
    private PerseguidorScript ghost;
    public bool endGame;
    private void Awake()
    {
        intance = this;
        source = GetComponent<AudioSource>();
        LayoutRandomizer.onPostLayout += OnPostLayout;
        playerSkeleton = GameObject.FindObjectOfType<CuerpoScript>();
        goblin = GameObject.FindObjectOfType<LadronScript>();
        ghost = GameObject.FindObjectOfType<PerseguidorScript>();
        playerSkeleton.onDead += OnPlayerDeath;
        playerSkeleton.onCatch += OnCatch;
        goblin.onTakenCoins += OnTakeCoins;
    }

    private void Start()
    {
        Invoke("DisableStarter", 3f);
    }

    void DisableStarter()
    {
        starter.SetActive(false);
    }

    private void Update()
    {
        if(endGame)
        {
            cam.SetEndPosCamera(playerSkeleton.transform);
            goblin.GetComponent<NavMeshAgent>().enabled = false;
            ghost.speed = 0;
        }
    }

    void OnPostLayout()
    {
        TeleportCharacters();
    }

    void TeleportCharacters()
    {
        playerSkeleton.transform.position = GameObject.FindWithTag("SpawnPlayer").transform.position;
        goblin.transform.position = GameObject.FindWithTag("SpawnLadron").transform.position;
        ghost.transform.position = GameObject.FindWithTag("SpawnGhost").transform.position;
    }

    void OnPlayerDeath(CuerpoScript s)
    {
        s.GetComponentInChildren<Animator>().Play("Death");
        endGame = true;
        source.clip = loseGhost;
      
        source.Play();
        GameOver();
    }

    void OnCatch(CuerpoScript s)
    {
        endGame = true;
        s.head.SetActive(true);
        s.GetComponentInChildren<Animator>().Play("Victory");
        source.clip = win;

        source.Play();
        Win();
    }

    void OnTakeCoins(LadronScript l)
    {
        endGame = true;
        playerSkeleton.GetComponentInChildren<Animator>().Play("Death");
        source.clip = loseGoblin;

        source.Play();
        GameOver();
    }

    void GameOver()
    {
        music.volume = 0;
        //Time.timeScale = 0;
        endGameUI.SetActive(true);
        
        playerSkeleton.enabled = false;
        gameOverScreen.SetActive(true);
        //Invoke("ResetGame", 3);
    }

    void Win()
    {
        music.volume = 0;
        //Time.timeScale = 0;
        endGameUI.SetActive(true);
        goblin.GetComponent<NavMeshAgent>().enabled = false;
        playerSkeleton.enabled = false;
        victoryScreen.SetActive(true);
        //Invoke("ResetGame",3);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
