using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movement")]
    [SerializeField] private float speed = 4f;
    private float direction;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private Transform checkGround;
    [SerializeField] private float raycastlength;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        Jump();
        AnimateMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.Raycast(checkGround.position, Vector2.down, raycastlength, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
        else if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void AnimateMovement()
    {
        animator.SetBool("IsJumping", !isGrounded);

        animator.SetBool("IsMoving", direction != 0);
    }
}