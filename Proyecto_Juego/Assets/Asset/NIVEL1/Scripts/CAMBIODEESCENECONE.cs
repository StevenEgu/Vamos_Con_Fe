using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Necesario para usar TextMeshPro

public class CAMBIODEESCENACONE : MonoBehaviour
{
    // Variable para verificar si el jugador está dentro del trigger
    private bool dentroDelTrigger = false;

    // Variable pública para el índice de la escena que se cambiará. 
    // Esto permite que puedas asignar el índice de la escena desde el Inspector.
    [SerializeField] private int escenaSiguiente; // Índice de la escena que quieres cargar

    // Referencia al texto de TMP que aparecerá cuando el jugador esté en el trigger
    [SerializeField] private TMP_Text mensajeTexto;  // Referencia al texto de TMP

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el texto esté desactivado al principio
        if (mensajeTexto != null)
        {
            mensajeTexto.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador está dentro del trigger, y presiona la tecla 'E', cambiar de nivel
        if (dentroDelTrigger && Input.GetKeyDown(KeyCode.E))
        {
            CambiarNivel();
        }
    }

    // Método para cambiar de nivel
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
            dentroDelTrigger = true; // Activar la opción de presionar "E"

            // Mostrar el mensaje en el texto de TMP
            if (mensajeTexto != null)
            {
                mensajeTexto.gameObject.SetActive(true);  // Mostrar el texto
                mensajeTexto.text = "Presiona E para cambiar de nivel";  // Cambiar el texto
            }
        }
    }

    // Detectar cuando el jugador sale del trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si el jugador sale del trigger
       // if (collision.gameObject.CompareTag("Player"))
      //  {
        //    Debug.Log("Jugador fuera del trigger.");
        //    dentroDelTrigger = false; // Desactivar la opción de presionar "E"

            // Ocultar el mensaje cuando el jugador salga del trigger
         //   if (mensajeTexto != null)
          //  {
            //    mensajeTexto.gameObject.SetActive(false);  // Ocultar el texto
          //  }
       // }
    }
}
