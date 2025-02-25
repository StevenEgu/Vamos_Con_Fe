using UnityEngine;
using UnityEngine.UI;

public class Cuaderno : MonoBehaviour
{
    public Image paginaImage;  // Imagen donde se muestra la p�gina del cuaderno
    public Sprite[] paginas;   // Arreglo de sprites con las im�genes de las p�ginas
    private int paginaActual = 0; // P�gina actual

    public Button botonAvanzar;  // Bot�n para avanzar
    public Button botonRetroceder;  // Bot�n para retroceder

    void Start()
    {
        // Aseg�rate de que los botones llamen a los m�todos correctos al hacer clic
        botonAvanzar.onClick.AddListener(AvanzarPagina);
        botonRetroceder.onClick.AddListener(RetrocederPagina);

        // Mostrar la primera p�gina
        MostrarPagina();
    }

    void MostrarPagina()
    {
        if (paginaActual >= 0 && paginaActual < paginas.Length)
        {
            paginaImage.sprite = paginas[paginaActual];  // Cambia la imagen de la p�gina
        }
    }

    void AvanzarPagina()
    {
        if (paginaActual < paginas.Length - 1)  // Si no estamos en la �ltima p�gina
        {
            paginaActual++;
            MostrarPagina();
        }
    }

    void RetrocederPagina()
    {
        if (paginaActual > 0)  // Si no estamos en la primera p�gina
        {
            paginaActual--;
            MostrarPagina();
        }
    }
}
