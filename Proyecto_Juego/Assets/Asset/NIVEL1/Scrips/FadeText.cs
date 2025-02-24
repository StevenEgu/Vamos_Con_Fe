using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para los botones

public class FadeText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Referencia al TextMeshPro dentro del panel
    public Button fadeButton; // Referencia al botón que ejecutará el desvanecimiento
    public float fadeInDuration = 1f; // Duración del desvanecimiento al aparecer
    public float timeBeforeFadeOut = 2f; // Tiempo que el texto permanece visible antes de desvanecerse
    public float fadeOutDuration = 2f; // Duración del desvanecimiento al desaparecer

    private void Start()
    {
        // Asegurarse de que el texto comienza invisible
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 0f);

        // Agregar la función al evento de clic del botón
        fadeButton.onClick.AddListener(OnButtonClick);
    }

    // Método que se llama al presionar el botón
    private void OnButtonClick()
    {
        // Comienza la corutina de desvanecimiento del texto
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        // Fade In: Hacer que el texto se haga visible
        float elapsedTime = 0f;

        // Desvanecer el texto hacia la visibilidad
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration); // De invisible a visible
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }

        // Asegurarse de que el texto esté completamente visible
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 1f);

        // Espera el tiempo que debe permanecer visible
        yield return new WaitForSeconds(timeBeforeFadeOut);

        // Fade Out: Hacer que el texto se desvanezca
        elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration); // De visible a invisible
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }

        // Asegurarse de que el texto esté completamente invisible
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 0f);
    }
}
