using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public Slider rowSlider;
    public Slider colSlider;
    public Text rowText;
    public Text colText;

    void Awake() => instance = this;

    public void PlayTheGame(string _sceneName)
    {
        Data.col = (int)colSlider.value;
        Data.row = (int)rowSlider.value;
        SceneManager.LoadScene(_sceneName);
    }

    public void OnChangeValueSlider()
    {
        rowText.text = rowSlider.value.ToString();
        colText.text = colSlider.value.ToString();

    }

}
    
    
    
