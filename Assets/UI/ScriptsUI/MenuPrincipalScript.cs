using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject settingOptions;

    [SerializeField]
    private GameObject instructions;

    [SerializeField]
    private GameObject credits;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        settingOptions.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Instructions()
    {
        instructions.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Credits()
    {
        credits.SetActive(true);
        gameObject.SetActive(false);
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
