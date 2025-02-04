using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Velocidad de movimiento
    public float jumpForce = 10f;         // Fuerza del salto
    public Transform groundCheck;         // Objeto vacío en los pies para detectar suelo
    public LayerMask groundLayer;         // Capa del suelo

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private bool canMove = false;         // Inicialmente desactivado

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!canMove) return;  // Bloquear movimiento hasta que se habilite

        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Invertir dirección del personaje
        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        // Animación de movimiento
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Comprobar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    // Método para habilitar el movimiento
    public void EnableMovement()
    {
        canMove = true;
    }
}
