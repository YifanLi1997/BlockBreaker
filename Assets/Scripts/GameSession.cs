using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    // config paras
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 10;
    [SerializeField] bool isAutoPlay;


    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlay;
    }
}
