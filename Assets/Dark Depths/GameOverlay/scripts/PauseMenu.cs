using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        gameIsPaused = false;
        if (instance == null)
            instance = this;
    }

    public void OnMenuOpenAndClose(InputValue escapeButton)
    {
        if (escapeButton.isPressed)
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
