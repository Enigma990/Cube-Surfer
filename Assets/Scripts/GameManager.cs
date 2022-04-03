using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] private Text scoreText = null;

    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject gamePanel = null;
    [SerializeField] private GameObject completePanel = null;
    [SerializeField] private GameObject failPanel = null;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = _score.ToString();
    }

    public void LevelComplete()
    {
        Time.timeScale = 0f;

        completePanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void LevelFailed()
    {
        Time.timeScale = 0f;

        failPanel.SetActive(true);
        gamePanel.SetActive(failPanel);
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClick_MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
