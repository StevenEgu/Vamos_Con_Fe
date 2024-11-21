using UnityEngine;

public class BoardController : MonoBehaviour
{
    public int hitsToBreak = 3;   // N�mero de saltos que el jugador necesita para romper los tablones
    private int currentHits = 0;  // Contador de saltos recibidos sobre el tabl�n

    // Detecta la colisi�n con el jugador
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Aumenta el contador de saltos
            currentHits++;

            // Si el n�mero de saltos alcanza el l�mite, destruye el tabl�n
            if (currentHits >= hitsToBreak)
            {
                Destroy(gameObject);  // Destruye el objeto del tabl�n
                Debug.Log("�El tabl�n ha sido roto!");
            }
        }
    }
}
