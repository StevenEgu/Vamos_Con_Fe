using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esta referencia para trabajar con UI
using TMPro; // Si necesitas TextMeshPro
using System.Collections; // Importa el namespace necesario para IEnumerator

public class SofaDesbloqueaCocina : MonoBehaviour
{
    // Referencias a los botones, panel y otros componentes
    public Button botonSofa;
    public Button botonLlave;
    public Button botonCajonCocina; // Botón que queremos activar
    public GameObject panelLlave;
    public Button botonDesactivado; // Referencia al botón desactivado que quieres activar

    private void Start()
    {
        // Asegúrate de que el panel y el botón desactivado estén ocultos al principio
        panelLlave.SetActive(false);
        if (botonDesactivado != null)
        {
            botonDesactivado.gameObject.SetActive(false); // Desactivar el botón inicialmente
        }

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

        // Activar el botón desactivado
        if (botonDesactivado != null)
        {
            botonDesactivado.gameObject.SetActive(true); // Activar el botón desactivado
        }

        // Destruir los botones (Botón Sofá y Botón Llave)
        Destroy(botonSofa.gameObject);  // Destruir el botón Sofá
        Destroy(botonLlave.gameObject); // Destruir el botón Llave
    }
}
