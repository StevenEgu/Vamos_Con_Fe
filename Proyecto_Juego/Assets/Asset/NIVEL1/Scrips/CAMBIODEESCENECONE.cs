using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CAMBIODEESCENACONE : MonoBehaviour
{
    // Variable para verificar si el jugador est� dentro del trigger
    private bool dentroDelTrigger = false;

    // Variable p�blica para el �ndice de la escena que se cambiar�. 
    // Esto permite que puedas asignar el �ndice de la escena desde el Inspector.
    [SerializeField] private int escenaSiguiente; // �ndice de la escena que quieres cargar

    // Start is called before the first frame update
    void Start()
    {
        // Inicializaci�n si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador est� dentro del trigger, y presiona la tecla 'E', cambiar de nivel
        if (dentroDelTrigger && Input.GetKeyDown(KeyCode.E))
        {
            CambiarNivel();
        }
    }

    // M�todo para cambiar de nivel
    [ContextMenu("boton cambiar nivel")]
    public void CambiarNivel()
    {
        // Cambiar al nivel especificado en la variable escenaSiguiente
        SceneManager.LoadScene(escenaSiguiente);
    }

    // Detectar cuando el jugador entra en el trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el jugador entra en el trigger
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador dentro del trigger. Presiona E para cambiar de nivel.");
            dentroDelTrigger = true; // Activar la opci�n de presionar "E"
        }
    }

    // Detectar cuando el jugador sale del trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si el jugador sale del trigger
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador fuera del trigger.");
            dentroDelTrigger = false; // Desactivar la opci�n de presionar "E"
        }
    }
}
