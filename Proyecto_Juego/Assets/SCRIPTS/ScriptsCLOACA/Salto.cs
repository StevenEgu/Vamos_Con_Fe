using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float moveSpeed = 5f;          // Velocidad de movimiento horizontal
    public float jumpForce = 10f;         // Fuerza del salto
    private Rigidbody2D rb;
    private bool isGrounded = false;      // Verifica si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Comprobar si está en el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
