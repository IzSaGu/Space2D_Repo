using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Move Parameters")]
    [SerializeField] float speed;
    [SerializeField] float limitY = -10;


    [Header("General References")]
    [SerializeField] GameObject enemyBody;
    [SerializeField] PolygonCollider2D enemyCol;
    //[SerializeField] Animator enemyAnim;

    private void Awake()
    {
        enemyCol = GetComponent<PolygonCollider2D>();
        //enemyAnim = enemyBody.GetComponent<Animator>();
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
    }

    void EnemyMove()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}