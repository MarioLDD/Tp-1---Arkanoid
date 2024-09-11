using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score = 0;
    private int bricksLenght;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
        }
    }

    void Start()
    {
        scoreText.text = $"Score: {score}";
        bricksLenght = FindObjectsOfType<Brick>().Length;
    }

    private void OnEnable()
    {
        Brick.OnBrickEvent += UpdateScoreText;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Brick.OnBrickEvent -= UpdateScoreText;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void UpdateScoreText(int value)
    {
        score += value;
        scoreText.text = $"Score: {score}";
        BrickCounter();
    }

    private void BrickCounter()
    {
        bricksLenght--;

        if (bricksLenght == 0)
        {
            MenuManager.Instance.Victory();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
        scoreText.text = $"Score: {score}";
        bricksLenght = FindObjectsOfType<Brick>().Length;

    }

}
