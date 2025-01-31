using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Bullet : MonoBehaviour
{
    [Header("Bullet Configuration")]
    [SerializeField] float speed = 10;
    [SerializeField] float limitY;

    public int score = 0;
    public Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        //Movimiento
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //limitador de pantalla
        if (transform.position.y >= limitY) gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Sumar puntos
            AddScore(10);

            // Destruir la nave enemiga
            Destroy(other.gameObject);
        }
    }

    void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}



