using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public float tiempoTotal = 60f; 
    public Text textoContador; 

    void Start()
    {
        StartCoroutine(IniciarCuentaAtras());
    }

    IEnumerator IniciarCuentaAtras()
    {
        float tiempoRestante = tiempoTotal;

        while (tiempoRestante > 0)
        {
            textoContador.text = "Tiempo restante: " + Mathf.Ceil(tiempoRestante).ToString();
            yield return new WaitForSeconds(1f);
            tiempoRestante--;
        }

        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Win-next");
    }
}
