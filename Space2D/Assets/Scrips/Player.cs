using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float speed =4f;
    private float direction;


    [Header("Jump")]
    [SerializeField] private float jumpForce - 4f;
    [SerializeField] private Transform checkGround;
    [SerializeField] private float raycastlength;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void Jump()
    {
        isGrounded = Physics2D.Raycast(checkGround.position, Vector2.down, _raycastLength, groundLayer);
    }
}
