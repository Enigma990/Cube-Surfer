using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    [SerializeField] private GameObject mainMenuPanel = null;
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject gamePanel = null;
    [SerializeField] private GameObject completePanel = null;
    [SerializeField] private GameObject failPanel = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        if (CheckRestart.instance.bIsRestarted)
        {
            OnClick_PlayBtn();
            CheckRestart.instance.bIsRestarted = false;
        }
    }

    public void OnClick_PlayBtn()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);

        Time.timeScale = 1f;
    }

    public void OnClick_PauseBtn()
    {
        Time.timeScale = 0f;

        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void OnClick_ResumeBtn()
    {
        Time.timeScale = 1f;

        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void OnClick_RestartBtn()
    {
        Time.timeScale = 1f;

        CheckRestart.instance.bIsRestarted = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClick_MainMenu()
    {
        Time.timeScale = 0f;

        mainMenuPanel.SetActive(true);
        failPanel.SetActive(false);
        completePanel.SetActive(false);
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);

        CheckRestart.instance.bIsRestarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClick_ExitBtn()
    {
        Application.Quit();
    }

    public void LevelFailed()
    {
        failPanel.SetActive(true);
        gamePanel.SetActive(failPanel);
    }

    public void LevelComplete()
    {
        completePanel.SetActive(true);
        gamePanel.SetActive(false);
    }

}
