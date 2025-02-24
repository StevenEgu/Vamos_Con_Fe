using UnityEngine;

public class MoJuaneta : MonoBehaviour
{
    public float moveSpeed = 5f;          // Velocidad de movimiento
    public float jumpForce = 10f;         // Fuerza del salto
    public Transform playerGroundCheck;   // Objeto vac�o en los pies para detectar suelo
    public LayerMask playerGroundLayer;   // Capa del suelo

    private Rigidbody2D rb;
    private Animator animator;
    private bool isPlayerGrounded = false;  // Estado de si est� tocando el suelo
    private bool isMovementEnabled = false; // Si el movimiento est� habilitado

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ActivateMovement();  // Habilitar el movimiento desde el inicio
    }

    void Update()
    {
        if (!isMovementEnabled) return;  // Si el movimiento no est� habilitado, no se mueve.

        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);  // Actualiza la velocidad en el eje X

        // Invertir direcci�n del personaje dependiendo de la tecla presionada
        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);  // Cambiar la direcci�n del personaje

        // Comprobar si el jugador est� en el suelo
        bool isGroundedNow = Physics2D.OverlapCircle(playerGroundCheck.position, 0.1f, playerGroundLayer);

        // Solo mostrar el mensaje cuando cambia el estado de "Grounded"
        if (isGroundedNow != isPlayerGrounded)
        {
            isPlayerGrounded = isGroundedNow;
            Debug.Log("Is Grounded: " + isPlayerGrounded);  // Solo mostrar cuando cambia
        }

        // Animaci�n de movimiento
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)  // Si se presiona la barra espaciadora y est� en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Aplica una fuerza en Y para saltar
            animator.SetTrigger("Jump");
        }

        // Dibuja un rayo para visualizar la posici�n de playerGroundCheck
        //Debug.DrawRay(playerGroundCheck.position, Vector2.down * 0.1f, Color.red); // Dibuja un rayo hacia abajo
    }

    // M�todo para habilitar el movimiento
    public void ActivateMovement()
    {
        isMovementEnabled = true;  // Habilita el movimiento
    }
}
