using System.Collections;
using TMPro; // Importar el espacio de nombres de TextMeshPro
using UnityEngine;

public class Texto_indicación_2 : MonoBehaviour
{
    string frase = "...para romper las maderas...¡SALTA!";
    public TMP_Text texto; // Referencia al texto
    public float tiempoDesvanecimiento = 1f; // Duración del desvanecimiento
    public GameObject jugador; // Referencia al jugador
    private Control_niña_calle controlNiñaCalle; // Referencia al script de movimiento

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el componente de movimiento del jugador y deshabilitarlo al inicio
        controlNiñaCalle = jugador.GetComponent<Control_niña_calle>(); // Cambia esto por el nombre de tu script de movimiento
        controlNiñaCalle.enabled = false; // Deshabilitar el movimiento al principio
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        // Mostrar texto carácter por carácter
        texto.text = ""; // Asegurarse de que el texto comience vacío
        foreach (char caracter in frase)
        {
            texto.text += caracter; // Añadir el carácter actual
            yield return new WaitForSeconds(0.1f);
        }

        // Iniciar el desvanecimiento
        yield return StartCoroutine(FadeOut());

        // Rehabilitar el movimiento después del desvanecimiento
        controlNiñaCalle.ActivateMovement(); // Habilita el movimiento
    }

    IEnumerator FadeOut()
    {
        Color originalColor = texto.color; // Obtener el color original
        float elapsedTime = 0f;

        // Realizar el desvanecimiento
        while (elapsedTime < tiempoDesvanecimiento)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / tiempoDesvanecimiento); // Interpolar alpha
            texto.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha); // Actualizar color
            yield return null; // Esperar al siguiente frame
        }

        texto.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Asegurar alpha en 0
    }
}
