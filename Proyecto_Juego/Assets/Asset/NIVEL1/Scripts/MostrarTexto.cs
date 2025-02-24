using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class MostrarTexto : MonoBehaviour
{
    public TextMeshProUGUI popupText; // Referencia al TextMesh Pro
    public Button myButton; // Referencia al bot�n
    public float timeToDisappear = 2f; // Tiempo que se mostrar� el texto
    public float fadeDuration = 1f; // Duraci�n del desvanecimiento

    void Start()
    {
        // Aseg�rate de que el texto est� desactivado al inicio
        popupText.gameObject.SetActive(false);
        Color textColor = popupText.color;
        textColor.a = 0f; // Inicialmente completamente transparente
        popupText.color = textColor;

        // Configura la acci�n del bot�n
        myButton.onClick.AddListener(OnButtonClick);
    }

    // Aseg�rate de que el m�todo sea p�blico
    public void OnButtonClick()  // Este m�todo es ahora p�blico
    {
        // Muestra el texto
        popupText.gameObject.SetActive(true);
        Color textColor = popupText.color;
        textColor.a = 1f; // Aseg�rate de que el texto sea completamente visible
        popupText.color = textColor;

        // Inicia una corutina para ocultar el texto despu�s de un tiempo
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
            // Interpolaci�n para el cambio de opacidad
            float alpha = Mathf.Lerp(startColor.a, 0f, timeElapsed / fadeDuration);
            startColor.a = alpha;
            popupText.color = startColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Aseg�rate de que la opacidad sea 0 al final
        startColor.a = 0f;
        popupText.color = startColor;

        // Deja el texto visible para la pr�xima vez
        popupText.gameObject.SetActive(false); // Desactiva el texto despu�s de desvanecerse
    }
}
