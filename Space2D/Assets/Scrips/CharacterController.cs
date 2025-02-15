using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;

    

    
    void Update()
    {
        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
    }
}
