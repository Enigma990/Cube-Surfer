using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] private TMP_Text scoreText = null;


    private void Awake()
    {
        instance = this;

        Time.timeScale = 0f;
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = _score.ToString();
    }

    public void LevelComplete()
    {
        Time.timeScale = 0f;

        MainMenu.instance.LevelComplete();

    }

    public void LevelFailed()
    {
        Time.timeScale = 0f;

        MainMenu.instance.LevelFailed();
    }

}
