using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    
    public static GameOver instance{ get; private set; }
    public GameObject gameOverMenu;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }
    
    public void Setup(int score)
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        pointsText.text = score.ToString();
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
