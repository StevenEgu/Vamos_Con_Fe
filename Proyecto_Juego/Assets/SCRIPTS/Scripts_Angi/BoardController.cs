using UnityEngine;

public class BoardController : MonoBehaviour
{
    public int hitsToBreak = 3;   // Número de saltos que el jugador necesita para romper los tablones
    private int currentHits = 0;  // Contador de saltos recibidos sobre el tablón

    // Detecta la colisión con el jugador
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Aumenta el contador de saltos
            currentHits++;

            // Si el número de saltos alcanza el límite, destruye el tablón
            if (currentHits >= hitsToBreak)
            {
                Destroy(gameObject);  // Destruye el objeto del tablón
                Debug.Log("¡El tablón ha sido roto!");
            }
        }
    }
}
