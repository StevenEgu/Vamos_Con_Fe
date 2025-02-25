using UnityEngine;
using UnityEngine.UI;

public class Cuaderno : MonoBehaviour
{
    public Image paginaImage;  // Imagen donde se muestra la página del cuaderno
    public Sprite[] paginas;   // Arreglo de sprites con las imágenes de las páginas
    private int paginaActual = 0; // Página actual

    public Button botonAvanzar;  // Botón para avanzar
    public Button botonRetroceder;  // Botón para retroceder

    void Start()
    {
        // Asegúrate de que los botones llamen a los métodos correctos al hacer clic
        botonAvanzar.onClick.AddListener(AvanzarPagina);
        botonRetroceder.onClick.AddListener(RetrocederPagina);

        // Mostrar la primera página
        MostrarPagina();
    }

    void MostrarPagina()
    {
        if (paginaActual >= 0 && paginaActual < paginas.Length)
        {
            paginaImage.sprite = paginas[paginaActual];  // Cambia la imagen de la página
        }
    }

    void AvanzarPagina()
    {
        if (paginaActual < paginas.Length - 1)  // Si no estamos en la última página
        {
            paginaActual++;
            MostrarPagina();
        }
    }

    void RetrocederPagina()
    {
        if (paginaActual > 0)  // Si no estamos en la primera página
        {
            paginaActual--;
            MostrarPagina();
        }
    }
}
