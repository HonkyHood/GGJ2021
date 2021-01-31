using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;

    [SerializeField]
    private GameObject gameUI;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !isPaused)
        {
            Pause();
            isPaused = true;
        }

        else if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && isPaused)
        {
            Unpause();
            isPaused = false;
        }
    }

    private void Unpause()
    {
        Time.timeScale = 1f;

        gameUI.gameObject.SetActive(true);

        pause.SetActive(!pause.activeSelf);
    }

 
    public void Pause()
    {
        Time.timeScale = 0f;

        gameUI.gameObject.SetActive(false);

        pause.SetActive(!pause.activeSelf);
    }

}
