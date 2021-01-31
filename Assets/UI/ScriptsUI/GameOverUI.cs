using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameUI;

    [SerializeField]
    private GameObject victoryUI;

    [SerializeField]
    private GameObject defeatUI;

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MenuLoad()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;//No sé si esto funca pero por si las dudas
    }

    public void ExitProgram()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void DisplayVictoryScreen()
    {
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
        victoryUI.SetActive(true);
    }
    public void DisplayDefeatScreen()
    {
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
        defeatUI.SetActive(true);
    }
}
