using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [Header("Bullet Configuration")]
    [SerializeField] float speed = 10;
    [SerializeField] float limitY;



    void Update()
    {
        //Movimiento
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //limitador de pantalla
        if (transform.position.y >= limitY) gameObject.SetActive(false);
    }
}



