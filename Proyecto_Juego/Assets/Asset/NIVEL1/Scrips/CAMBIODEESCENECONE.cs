using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Necesario para usar TextMeshPro

public class CAMBIODEESCENACONE : MonoBehaviour
{
    // Variable para verificar si el jugador est� dentro del trigger
    private bool dentroDelTrigger = false;

    // Variable p�blica para el �ndice de la escena que se cambiar�. 
    // Esto permite que puedas asignar el �ndice de la escena desde el Inspector.
    [SerializeField] private int escenaSiguiente; // �ndice de la escena que quieres cargar

    // Referencia al texto de TMP que aparecer� cuando el jugador est� en el trigger
    [SerializeField] private TMP_Text mensajeTexto;  // Referencia al texto de TMP

    // Start is called before the first frame update
    void Start()
    {
        // Aseg�rate de que el texto est� desactivado al principio
        if (mensajeTexto != null)
        {
            mensajeTexto.gameObject.SetActive(false);
        }
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
        //    dentroDelTrigger = false; // Desactivar la opci�n de presionar "E"

            // Ocultar el mensaje cuando el jugador salga del trigger
         //   if (mensajeTexto != null)
          //  {
            //    mensajeTexto.gameObject.SetActive(false);  // Ocultar el texto
          //  }
       // }
    }
}
