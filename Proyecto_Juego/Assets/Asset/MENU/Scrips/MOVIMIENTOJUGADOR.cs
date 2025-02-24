using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIMIENTOJUGADOR : MonoBehaviour
{
    [HideInInspector] public int lives;
    [Header("Jugador")]
    [Space(10)]
    [TextArea(minLines: 2, maxLines: 4)]
    [SerializeField] private string DescripcionJugador;

    [Header("Movimiento")]
    [Range(2f, 20f)]
    [Space(10)]
    [SerializeField] private float VelocidadJugador = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator animator; // Referencia al componente Animator

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener entrada de movimiento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);

        // Actualizar el parámetro "Speed" en el Animator para la animación de caminar a los lados
        animator.SetFloat("Speed", Mathf.Abs(moveX));  // Movimiento horizontal

        // Determinar la animación a reproducir en función del movimiento
        if (moveX > 0) // Si el jugador se mueve a la derecha
        {
            animator.SetBool("IsMoving", true);
            animator.Play("CaminarDerecha");  // Asumimos que esta es la animación de caminar hacia la derecha
        }
        else if (moveX < 0) // Si el jugador se mueve a la izquierda
        {
            animator.SetBool("IsMoving", true);
            animator.Play("CaminarIzquierda");  // Asumimos que esta es la animación de caminar hacia la izquierda
        }
        else if (moveY > 0) // Si el jugador se mueve hacia arriba
        {
            animator.SetBool("IsMoving", true);
            animator.Play("Arriba");  // Animación de caminar hacia arriba
        }
        else if (moveY < 0) // Si el jugador se mueve hacia abajo
        {
            animator.SetBool("IsMoving", true);
            animator.Play("Abajo");  // Animación de caminar hacia abajo
        }
        else
        {
            animator.SetBool("IsMoving", false);  // Si no hay movimiento, ponemos IsMoving a false para ir al estado de idle
        }

        // Voltear el personaje en función de la dirección
        if (moveX > 0) // Si el jugador se mueve hacia la derecha
        {
            transform.localScale = new Vector3(1, 1, 1); // Normal (mirando hacia la derecha)
        }
        else if (moveX < 0) // Si el jugador se mueve hacia la izquierda
        {
            transform.localScale = new Vector3(-1, 1, 1); // Volteado (mirando hacia la izquierda)
        }
    }

    private void FixedUpdate()
    {
        // Aplicar el movimiento
        playerRb.MovePosition(playerRb.position + moveInput * VelocidadJugador * Time.fixedDeltaTime);
    }
}
