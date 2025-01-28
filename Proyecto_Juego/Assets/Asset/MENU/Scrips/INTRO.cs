using System.Collections;
using UnityEngine;
using TMPro; // Asegúrate de tener este using para usar TextMeshPro
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("Texto y Estilo de la Intro")]
    [SerializeField] private TMP_Text textoIntro; // Componente de TextMeshPro para el texto de la intro
    [SerializeField] private string[] parrafos; // Array de párrafos que se mostrarán en la intro
    [SerializeField] private float velocidadEscritura = 0.05f; // Velocidad con la que aparece el texto
    [SerializeField] private string nombreEscena; // Nombre de la escena a la que se debe cambiar

    private int indiceParrafo = 0; // Índice para recorrer el array de párrafos
    private bool textoCompleto = false; // Indica si el texto completo del párrafo ha sido mostrado

    private void Start()
    {
        // Comienza la intro mostrando el primer párrafo
        if (parrafos.Length > 0)
        {
            StartCoroutine(MostrarTexto(parrafos[indiceParrafo]));
        }
    }

    private void Update()
    {
        // Avanza al siguiente párrafo cuando se presiona la tecla 'E' y el texto ha sido completado
        if (textoCompleto && Input.GetKeyDown(KeyCode.E))
        {
            // Resetea la visibilidad del texto y muestra el siguiente párrafo
            textoIntro.text = "";
            indiceParrafo++;

            if (indiceParrafo < parrafos.Length)
            {
                // Muestra el siguiente párrafo
                StartCoroutine(MostrarTexto(parrafos[indiceParrafo]));
            }
            else
            {
                // Si ya no hay más párrafos, habilitar el botón para cambiar de escena
                CambiarEscena();
            }
        }
    }

    // Corrutina para mostrar el texto con el efecto de máquina de escribir
    private IEnumerator MostrarTexto(string texto)
    {
        textoIntro.text = "";
        textoCompleto = false;

        foreach (char letra in texto)
        {
            textoIntro.text += letra; // Añade la letra al texto
            yield return new WaitForSeconds(velocidadEscritura); // Espera antes de añadir la siguiente letra
        }

        // Cuando todo el texto esté visible, marcar como completo
        textoCompleto = true;
    }

    // Método para cambiar a la escena indicada
    private void CambiarEscena()
    {
        // Cambiar a la escena definida en el Inspector
        SceneManager.LoadScene(nombreEscena);
    }
}
