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
    [Range(2f,20f)]
    [Space(10)]
    [SerializeField] private float VelocidadJugador = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput= new Vector2(moveX, moveY);
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * VelocidadJugador * Time.fixedDeltaTime);
    }


}
