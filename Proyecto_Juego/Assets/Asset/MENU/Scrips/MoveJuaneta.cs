using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJuanita : MonoBehaviour
{
    public float moveSpeed = 5f;            // Velocidad de movimiento
    public float jumpForce = 10f;           // Fuerza de salto
    public Transform groundCheck;           // Transform que se utiliza para comprobar si el personaje est� tocando el suelo
    public LayerMask groundLayer;           // Capa de suelo (esto se usa para detectar el suelo)

    private Rigidbody2D rb;                 // Referencia al Rigidbody2D del jugador
    private Animator anim;                  // Referencia al Animator
    private bool isGrounded;                // Estado de si est� tocando el suelo
    private float groundCheckRadius = 0.2f; // Radio para comprobar si est� tocando el suelo

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Comprobaci�n si est� tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Movimiento del personaje
        float horizontalInput = Input.GetAxis("Horizontal"); // Obtiene la entrada de las teclas de direcci�n (izquierda/derecha)

        // Aplicar movimiento
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Control de animaciones
        if (Mathf.Abs(horizontalInput) > 0)
        {
            anim.SetBool("isRunning", true); // Activa la animaci�n de correr
            // Invertir la direcci�n de la animaci�n seg�n la direcci�n de movimiento
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }
        else
        {
            anim.SetBool("isRunning", false); // Desactiva la animaci�n de correr si no se est� moviendo
        }

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica la fuerza de salto
        }
    }
}
