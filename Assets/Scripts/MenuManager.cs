using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] private GameObject pause_Panel;
    [SerializeField] private GameObject victory_Panel;
    [SerializeField] private GameObject endGame_Panel;

    public bool IsPause;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        pause_Panel.SetActive(false);
        victory_Panel.SetActive(false);
        endGame_Panel.SetActive(false);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    private void Update()
    {

        if (!(SceneManager.GetActiveScene().name == "MainMenu"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        IsPause = !IsPause;

        if (IsPause)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            pause_Panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pause_Panel.SetActive(false);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        Time.timeScale = 1;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenesInBuildSettings = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < totalScenesInBuildSettings - 1)
        {
            int loadScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(loadScene);

        }
        else
        {
            SceneManager.LoadScene("MainMenu");

        }

    }
    public void Victory()
    {
        Time.timeScale = 0;
        victory_Panel.SetActive(true);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        endGame_Panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
