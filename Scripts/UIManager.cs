using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startScreen;
    public Button startButton;

    void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);
        // start screen visible by default
        if (startScreen != null) startScreen.SetActive(true);
        Time.timeScale = 0f; // pause game until start
    }

    void StartGame()
    {
        if (startScreen != null) startScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
