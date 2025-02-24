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
    }

    // Funci�n que activa el bot�n del caj�n de cocina, cierra el panel, y destruye los botones
    void ActivarLlave()
    {
        // Habilitar el bot�n del caj�n de cocina
        botonCajonCocina.interactable = true;

        // Cerrar el panel de la llave
        panelLlave.SetActive(false);

        // Mostrar el texto y luego hacer que se desvanezca
        StartCoroutine(MostrarTexto());

        // Destruir los botones (Bot�n Sof� y Bot�n Llave)
        Destroy(botonSofa.gameObject);  // Destruir el bot�n Sof�
        Destroy(botonLlave.gameObject); // Destruir el bot�n Llave
    }

    // Corutina para mostrar el texto
    IEnumerator MostrarTexto()
    {
        // Hacer visible el texto
        textoDesvanecerse.gameObject.SetActive(true);

        // Opcional: Aqu� puedes ajustar el texto que aparece
        textoDesvanecerse.text = "La llave de la cocina ha aparecido! Es momento de abrir el caj�n.";

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
