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
    }

    // Función que activa el botón del cajón de cocina, cierra el panel, y destruye los botones
    void ActivarLlave()
    {
        // Habilitar el botón del cajón de cocina
        botonCajonCocina.interactable = true;

        // Cerrar el panel de la llave
        panelLlave.SetActive(false);

        // Mostrar el texto y luego hacer que se desvanezca
        StartCoroutine(MostrarTexto());

        // Destruir los botones (Botón Sofá y Botón Llave)
        Destroy(botonSofa.gameObject);  // Destruir el botón Sofá
        Destroy(botonLlave.gameObject); // Destruir el botón Llave
    }

    // Corutina para mostrar el texto
    IEnumerator MostrarTexto()
    {
        // Hacer visible el texto
        textoDesvanecerse.gameObject.SetActive(true);

        // Opcional: Aquí puedes ajustar el texto que aparece
        textoDesvanecerse.text = "La llave de la cocina ha aparecido! Es momento de abrir el cajón.";

        // Esperar un poco para mostrar el texto
        yield return new WaitForSeconds(2f); // Esperar 2 segundos

        // Desvanecer el texto
        float tiempoDesvanecer = 1f; // Tiempo de desvanecimiento
        float t = 0;

        // Desvanecer el texto
        Color textoColor = textoDesvanecerse.color;
        while (t < tiempoDesvanecer)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / tiempoDesvanecer); // De opaco a transparente
            textoDesvanecerse.color = new Color(textoColor.r, textoColor.g, textoColor.b, alpha);
            yield return null;
        }

        // Desactivar el texto cuando termine de desvanecerse
        textoDesvanecerse.gameObject.SetActive(false);
    }
}
