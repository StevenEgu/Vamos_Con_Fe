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
    private AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip sonidoPasos; // El clip de sonido de los pasos

    private bool isWalking; // Para saber si el jugador está caminando

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        audioSource = GetComponent<AudioSource>(); // Obtener el componente AudioSource

        if (sonidoPasos != null)
        {
            audioSource.clip = sonidoPasos; // Asignar el sonido de pasos
            audioSource.loop = true; // Repetir el sonido de pasos
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener entrada de movimiento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);

        // Actualizar el parámetro "Speed" en el Animator para la animación
        animator.SetFloat("Speed", Mathf.Abs(moveX)); // Solo se actualiza si hay movimiento horizontal

        // Voltear el personaje en función de la dirección
        if (moveX > 0) // Si el jugador se mueve hacia la derecha
        {
            transform.localScale = new Vector3(1, 1, 1); // Normal (mirando hacia la derecha)
        }
        else if (moveX < 0) // Si el jugador se mueve hacia la izquierda
        {
            transform.localScale = new Vector3(-1, 1, 1); // Volteado (mirando hacia la izquierda)
        }

        // Comprobar si el jugador está caminando
        if (moveInput.magnitude > 0 && !isWalking) // Si el jugador comienza a moverse
        {
            PlayFootsteps();
        }
        else if (moveInput.magnitude == 0 && isWalking) // Si el jugador deja de moverse
        {
            StopFootsteps();
        }
    }

    private void FixedUpdate()
    {
        // Aplicar el movimiento
        playerRb.MovePosition(playerRb.position + moveInput * VelocidadJugador * Time.fixedDeltaTime);
    }

    private void PlayFootsteps()
    {
        if (audioSource != null && sonidoPasos != null)
        {
            audioSource.Play(); // Reproducir el sonido de pasos
            isWalking = true; // Marcar que el jugador está caminando
        }
    }

    private void StopFootsteps()
    {
        if (audioSource != null && sonidoPasos != null)
        {
            audioSource.Stop(); // Detener el sonido de pasos
            isWalking = false; // Marcar que el jugador ya no está caminando
        }
    }
}
