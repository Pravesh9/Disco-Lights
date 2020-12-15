using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Public Events For Scripts
    public static event Action OnPlayerWon;
    public static event Action OnGamePause;
    public static event Action OnGameResume;
    #endregion

    #region Public Events For Inspector Reference
    public UnityEvent _OnPlayerWon;
    public UnityEvent _OnGamePause;
    public UnityEvent _OnGameResume;
    #endregion


    private void Awake() => instance = this;

    public void PlayerWon()
    {
        //print("PlayerWon");
        DebugManager.LogWithColor("Player Won", Color.green);
        OnPlayerWon?.Invoke();
        _OnPlayerWon?.Invoke();
    }

    public void PauseTheGame()
    {
        DebugManager.LogWithColor("Game Has Pause", Color.red);
        OnGamePause?.Invoke();
        _OnGamePause?.Invoke();
    }
    public void ResumeTheGame()
    {
        DebugManager.LogWithColor("Game Has Resume", Color.green);
        OnGameResume?.Invoke();
        _OnGameResume?.Invoke();
    }

    public void LoadMenu(string _menuName)
    {
        SceneManager.LoadScene(_menuName);
    }
    public void RetryTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
