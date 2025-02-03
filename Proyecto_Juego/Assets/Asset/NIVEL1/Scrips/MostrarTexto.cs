using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class MostrarTexto : MonoBehaviour
{
    public TextMeshProUGUI popupText; // Referencia al TextMesh Pro
    public Button myButton; // Referencia al botón
    public float timeToDisappear = 2f; // Tiempo que se mostrará el texto
    public float fadeDuration = 1f; // Duración del desvanecimiento

    void Start()
    {
        // Asegúrate de que el texto esté desactivado al inicio
        popupText.gameObject.SetActive(false);
        Color textColor = popupText.color;
        textColor.a = 0f; // Inicialmente completamente transparente
        popupText.color = textColor;

        // Configura la acción del botón
        myButton.onClick.AddListener(OnButtonClick);
    }

    // Asegúrate de que el método sea público
    public void OnButtonClick()  // Este método es ahora público
    {
        // Muestra el texto
        popupText.gameObject.SetActive(true);
        Color textColor = popupText.color;
        textColor.a = 1f; // Asegúrate de que el texto sea completamente visible
        popupText.color = textColor;

        // Inicia una corutina para ocultar el texto después de un tiempo
        StartCoroutine(FadeOutText());
    }

    // Coroutine para hacer que el texto se desvanezca
    IEnumerator FadeOutText()
    {
        // Espera el tiempo antes de iniciar el desvanecimiento
        yield return new WaitForSeconds(timeToDisappear);

        // Realiza el desvanecimiento
        Color startColor = popupText.color;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            // Interpolación para el cambio de opacidad
            float alpha = Mathf.Lerp(startColor.a, 0f, timeElapsed / fadeDuration);
            startColor.a = alpha;
            popupText.color = startColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que la opacidad sea 0 al final
        startColor.a = 0f;
        popupText.color = startColor;

        // Deja el texto visible para la próxima vez
        popupText.gameObject.SetActive(false); // Desactiva el texto después de desvanecerse
    }
}
