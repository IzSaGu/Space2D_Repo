using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{


    [Header("Movement Parameters")]
    [SerializeField] float speed = 10;

    [Header("Attack Parameters")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 1.0f;

    //Varibles de autoreferencia
    Rigidbody2D playerRb;
    //PlayerInputHandle input;
    Animator playerAnim;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        //input = GetComponent<PlayerInputHandle>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        playerRb.AddForce(Vector3.up * speed * input.moveInput);
    }

    void Attack()
    {
        if (input.isAttacking && canAttack)
        {
            canAttack = false;
            Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }
    void ResetAttack()
    {
        input.isAttacking = false; //define que no estamos atacando
        canAttack = true; //define que podemos atacar
    }
}