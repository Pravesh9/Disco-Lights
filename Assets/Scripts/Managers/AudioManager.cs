using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnPlayerWon += PlayerWon;
    }
    private void OnDisable()
    {
        GameManager.OnPlayerWon -= PlayerWon;
    }

    void PlayerWon() => DebugManager.LogWithColor($"{this.name}: You can add here wining sound",Color.blue); 

}
