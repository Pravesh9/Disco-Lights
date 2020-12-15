using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    #region Public Variables
    public static LevelUIManager instance;
    public GameObject pausePanel;
    public GameObject winPanel;
    #endregion

    #region MonoBehaviour Method
    private void Awake() => instance = this;

    private void OnEnable()
    {
        GameManager.OnPlayerWon += PlayerWon;
        GameManager.OnGamePause += Pause;
        GameManager.OnGameResume += Resume;
    }
    private void OnDisable()
    {
        GameManager.OnPlayerWon -= PlayerWon;
        GameManager.OnGamePause -= Pause;
        GameManager.OnGameResume -= Resume;
    }
    #endregion

    #region OtherMethod
    void Pause()
    {
        pausePanel.Visible();
    }

    void Resume()
    {
        pausePanel.InVisible();
    }

    void PlayerWon()
    {
        winPanel.Visible();
    }
    #endregion 
}


