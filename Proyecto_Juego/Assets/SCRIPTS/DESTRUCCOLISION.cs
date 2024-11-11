using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTRUCCOLISION : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona tiene un tag específico (opcional)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruir el objeto que ha colisionado
            Destroy(collision.gameObject);

            // También puedes destruir el objeto actual si lo deseas
            // Destroy(gameObject);
        }
    }
}
