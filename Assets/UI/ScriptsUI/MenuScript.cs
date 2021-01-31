using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameUI;

    public void Continue()
    {
        Time.timeScale = 1f;

        gameUI.gameObject.SetActive(true);

        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void LoadMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
