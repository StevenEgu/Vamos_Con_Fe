using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Velocidad de movimiento horizontal
    public float jumpForce = 10f;         // Fuerza del salto
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;      // Verifica si el jugador está en el suelo
    private bool canMove = false;         // Control de movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

 
    }

    void Update()
    {
        if (!canMove) return;

        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Actualizar animación de movimiento
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Comprobar si está en el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        animator.SetBool("isGrounded", isGrounded);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }
}
