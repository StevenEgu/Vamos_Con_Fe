using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Velocidad de movimiento
    public float jumpForce = 10f;         // Fuerza del salto
    public Transform groundCheck;         // Objeto vac�o en los pies para detectar suelo
    public LayerMask groundLayer;         // Capa del suelo

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private bool canMove = false;         // Inicialmente desactivado

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Habilitar movimiento al inicio para pruebas
        EnableMovement();
    }

    void Update()
    {
        if (!canMove)
        {
            Debug.Log("Movimiento deshabilitado");
            return;  // Bloquear movimiento hasta que se habilite
        }

        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Verificar el movimiento
        Debug.Log("Movimiento en el eje X: " + move);

        // Invertir direcci�n del personaje
        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        // Animaci�n de movimiento
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Comprobar si est� en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        Debug.Log("Est� en el suelo: " + isGrounded);
        animator.SetBool("isGrounded", isGrounded);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
            Debug.Log("Salto realizado");
        }
    }

    // M�todo para habilitar el movimiento
    public void EnableMovement()
    {
        canMove = true;
        Debug.Log("Movimiento habilitado");
    }
}
