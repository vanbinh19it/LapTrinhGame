using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState{
        GamePlay,
        Pause,
        GameOver, 
        LevelUp
    }
    public GameState currentState;
    public GameState previousState;
    //UI
    public GameObject pauseScene;
    public GameObject resultScene;
    public GameObject lvUpScene;

    public Text currentHealthDisplay;
    public Text currentSpeedDisplay;
    public Text currentMightDisplay;
    public Text currentMagnetDisplay;

    public bool isGameOver=false;
    public bool choosingUpgrade;

    void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("EXTRA "+ this + "DELETED");
        }

        DisableScene();
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.GamePlay:
            CheckForPauseAndResume();
            break;
            case GameState.Pause:
            CheckForPauseAndResume();
            break;
            case GameState.GameOver:
                if(!isGameOver)
                {
                    isGameOver=true;
                    Time.timeScale=0;
                    Debug.LogWarning("Game Over");
                    DisplayResult();
                }
            break;
            case  GameState.LevelUp:
                if(!choosingUpgrade)
                {
                    choosingUpgrade = true;
                    Time.timeScale=0;
                    lvUpScene.SetActive(true);
                }
            break;
            default:
                Debug.LogWarning("STATE DOES NOT EXIT");
            break;
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if(currentState!= GameState.Pause)
        {
            previousState = currentState;
            ChangeState(GameState.Pause);
            pauseScene.SetActive(true);
            Time.timeScale=0f;
            Debug.Log("Pause");
        }
        

    }
    public void Resume()
    {
        if(currentState== GameState.Pause)
        {
            ChangeState(previousState);
            Time.timeScale=1f;
            pauseScene.SetActive(false);
            Debug.Log("Resume");
        }
    }

    void CheckForPauseAndResume()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Pause)
            {
                Resume();
            }
            else {
                PauseGame();
            }
        }
    }
    void DisableScene()
    {
        pauseScene.SetActive(false);
        resultScene.SetActive(false);
        lvUpScene.SetActive(false);
    }
    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    void DisplayResult()
    {
        resultScene.SetActive(true);
    }

    public void StartLvUp()
    {
        ChangeState(GameState.LevelUp);
    }
    public void EndLvUp()
    {
        choosingUpgrade = false;
        Time.timeScale = 1f;
        lvUpScene.SetActive(true);
        ChangeState(GameState.GamePlay);
    }

}
