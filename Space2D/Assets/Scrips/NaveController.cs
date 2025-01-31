using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{


    [Header("Movement Parameters")]
    [SerializeField] float speed = 10;

    [Header("Attack Parameters")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] bool canAttack = true;
    [SerializeField] float attackCooldown = 1.0f;

    [Header("Input Parameters")]
    [SerializeField] bool isAttacking;
    [SerializeField] Vector2 movement;

    //Varibles de autoreferencia
    Rigidbody2D playerRb;
    //PlayerInputHandle input;
    Animator playerAnim;
    PlayerInput input;


    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
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
        playerRb.AddForce(speed * movement);
    }

    void Attack()
    {
        if (isAttacking && canAttack)
        {
            canAttack = false;
            Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }
    void ResetAttack()
    {
        isAttacking = false; //define que no estamos atacando
        canAttack = true; //define que podemos atacar
    }

    
    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
        }
    }

    #endregion
}