using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action OnPlayerWon;

    private void Awake() => instance = this;

    public void PlayerWon()
    {
        //print("PlayerWon");
        DebugManager.LogWithColor("Player Won", Color.green);
        OnPlayerWon?.Invoke();
    }

}
