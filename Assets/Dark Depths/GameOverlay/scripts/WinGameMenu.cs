using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameMenu : MonoBehaviour
{
    public static WinGameMenu instance { get; private set; }
    public GameObject gameWinMenu;
    private int remainingMonsters;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        remainingMonsters = GameObject.FindGameObjectsWithTag("Enemies").Length;
    }

    public void CheckForVictory()
    {
        remainingMonsters-=1;

        Debug.Log("Monster died. Remaining monsters: " + remainingMonsters);

        if (remainingMonsters == 0)
        {
            ShowVictoryScreen();
        }
    }

    private void ShowVictoryScreen()
    {
        Time.timeScale = 0f;
        if (gameWinMenu != null)
        {
            gameWinMenu.SetActive(true);
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
