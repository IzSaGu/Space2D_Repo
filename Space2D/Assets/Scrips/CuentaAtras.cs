using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{
    public float timeRemaining = 30; 
    public Text timerText; 

    void Start()
    {
        UpdateTimerText();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            LoadNextScene();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Tiempo restante: " + Mathf.Ceil(timeRemaining).ToString();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("2");
    }
}
