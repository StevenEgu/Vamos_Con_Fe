using UnityEngine;
using UnityEngine.UI;
using TMPro; // Aseg�rate de incluir TextMeshPro
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
        // Aseg�rate de que el panel y el texto est�n ocultos al principio
        panelLlave.SetActive(false);
        textoDesvanecerse.gameObject.SetActive(false); // Desactivar el texto al inicio

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

        // Mostrar el texto sin que desaparezca
        MostrarTexto();

        // Destruir los botones (Bot�n Sof� y Bot�n Llave)
        Destroy(botonSofa.gameObject);  // Destruir el bot�n Sof�
        Destroy(botonLlave.gameObject); // Destruir el bot�n Llave
    }

    // Corutina para mostrar el texto
    void MostrarTexto()
    {
        // Hacer visible el texto
        textoDesvanecerse.gameObject.SetActive(true);

        // Opcional: Aqu� puedes ajustar el texto que aparece
        textoDesvanecerse.text = "�La llave de la cocina ha aparecido! Es momento de abrir el caj�n.!";
    }
}
