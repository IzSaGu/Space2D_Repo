using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Move Parameters")]
    [SerializeField] float speed;
    [SerializeField] float limitY = -10;


    [Header("General References")]
    [SerializeField] GameObject enemyBody;
    [SerializeField] PolygonCollider2D enemyCol;

    private void Awake()
    {
        enemyCol = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        EnemyMove();
        if (transform.position.y <= limitY) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(5);
            gameObject.SetActive(false);
        }
    }

    void EnemyMove()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}