using UnityEngine;
using UnityEngine.UI; // Aseg�rate de incluir esta referencia para trabajar con UI
using TMPro; // Si necesitas TextMeshPro
using System.Collections; // Importa el namespace necesario para IEnumerator

public class SofaDesbloqueaCocina : MonoBehaviour
{
    // Referencias a los botones, panel y otros componentes
    public Button botonSofa;
    public Button botonLlave;
    public Button botonCajonCocina; // Bot�n que queremos activar
    public GameObject panelLlave;
    public Button botonDesactivado; // Referencia al bot�n desactivado que quieres activar

    private void Start()
    {
        // Aseg�rate de que el panel y el bot�n desactivado est�n ocultos al principio
        panelLlave.SetActive(false);
        if (botonDesactivado != null)
        {
            botonDesactivado.gameObject.SetActive(false); // Desactivar el bot�n inicialmente
        }

        // Asignamos las funciones a los botones
        botonSofa.onClick.AddListener(AbrirPanel);
        botonLlave.onClick.AddListener(ActivarLlave);
    }

    // Funci�n que abre el panel con el bot�n sof�
    void AbrirPanel()
    {
        panelLlave.SetActive(true);
        Debug.Log("Panel de la llave abierto."); // Debug Log para ver si se ejecuta
    }

    // Funci�n que activa el bot�n del caj�n de cocina, cierra el panel, y destruye los botones
    void ActivarLlave()
    {
        // Debug Log para verificar si se est� activando la funci�n correctamente
        Debug.Log("Bot�n llave presionado. Activando bot�n caj�n cocina.");

        // Habilitar el bot�n del caj�n de cocina
        botonCajonCocina.interactable = true;

        // Verificar si el bot�n Caj�n Cocina es interactuable
        if (botonCajonCocina.interactable)
        {
            Debug.Log("Bot�n caj�n cocina ahora interactuable.");
        }
        else
        {
            Debug.Log("Bot�n caj�n cocina no es interactuable.");
        }

        // Cerrar el panel de la llave
        panelLlave.SetActive(false);

        // Activar el bot�n desactivado
        if (botonDesactivado != null)
        {
            botonDesactivado.gameObject.SetActive(true); // Activar el bot�n desactivado
        }

        // Destruir los botones (Bot�n Sof� y Bot�n Llave)
        Destroy(botonSofa.gameObject);  // Destruir el bot�n Sof�
        Destroy(botonLlave.gameObject); // Destruir el bot�n Llave
    }
}
