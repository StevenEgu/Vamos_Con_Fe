using UnityEngine;
using UnityEngine.UI;
using TMPro; // Asegúrate de incluir TextMeshPro
using System.Collections; // Importa el namespace necesario para IEnumerator

public class SofaDesbloqueaCocina : MonoBehaviour
{
    // Referencias a los botones, panel y texto
    public Button botonSofa;
    public Button botonLlave;
    public Button botonCajonCocina;
    public GameObject panelLlave;
    public TextMeshProUGUI textoDesvanecerse; // Referencia al componente de texto

    private void Start()
    {
        // Asegúrate de que el panel y el texto estén ocultos al principio
        panelLlave.SetActive(false);
        textoDesvanecerse.gameObject.SetActive(false); // Desactivar el texto al inicio

        // Asignamos las funciones a los botones
        botonSofa.onClick.AddListener(AbrirPanel);
        botonLlave.onClick.AddListener(ActivarLlave);
    }

    // Función que abre el panel con el botón sofá
    void AbrirPanel()
    {
        panelLlave.SetActive(true);
        Debug.Log("Panel de la llave abierto."); // Debug Log para ver si se ejecuta
    }

    // Función que activa el botón del cajón de cocina, cierra el panel, y destruye los botones
    void ActivarLlave()
    {
        // Debug Log para verificar si se está activando la función correctamente
        Debug.Log("Botón llave presionado. Activando botón cajón cocina.");

        // Habilitar el botón del cajón de cocina
        botonCajonCocina.interactable = true;

        // Verificar si el botón Cajón Cocina es interactuable
        if (botonCajonCocina.interactable)
        {
            Debug.Log("Botón cajón cocina ahora interactuable.");
        }
        else
        {
            Debug.Log("Botón cajón cocina no es interactuable.");
        }

        // Cerrar el panel de la llave
        panelLlave.SetActive(false);

        // Mostrar el texto sin que desaparezca
        MostrarTexto();

        // Destruir los botones (Botón Sofá y Botón Llave)
        Destroy(botonSofa.gameObject);  // Destruir el botón Sofá
        Destroy(botonLlave.gameObject); // Destruir el botón Llave
    }

    // Corutina para mostrar el texto
    void MostrarTexto()
    {
        // Hacer visible el texto
        textoDesvanecerse.gameObject.SetActive(true);

        // Opcional: Aquí puedes ajustar el texto que aparece
        textoDesvanecerse.text = "¡La llave de la cocina ha aparecido! Es momento de abrir el cajón.!";
    }
}
