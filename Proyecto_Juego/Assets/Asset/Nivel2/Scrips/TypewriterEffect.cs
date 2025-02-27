using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Importar SceneManager para cambiar de escena
using UnityEngine.UI; // Importar para usar Image en la transición

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI typewriterText; // Asigna aquí el componente TextMeshProUGUI desde el inspector.
    public string firstText = "Bienvenido al juego."; // Primer texto.
    public string secondText = "Prepárate para la aventura."; // Segundo texto.
    public float typingSpeed = 0.05f; // Velocidad de escritura.
    public float pauseBetweenTexts = 0.5f; // Pausa más corta entre textos.
    public string nextSceneName = "Sotano"; // Nombre de la siguiente escena.

    public AudioSource audioSource; // Fuente de audio para reproducir sonidos.
    public AudioClip typingSound; // Sonido de escribir.
    public AudioClip voiceSound; // Sonido de la voz (para el segundo texto).

    private bool isTypingSoundPlayed = false; // Para controlar que el sonido de escribir no se repita.
    private bool isVoiceSoundPlayed = false; // Para controlar que el sonido de voz no se repita.

    public Image fadeImage; // Referencia al Image para la transición de fade.
    public float fadeDuration = 1.0f; // Duración del fade.

    void Start()
    {
        StartCoroutine(ShowTexts());
    }

    IEnumerator ShowTexts()
    {
        // Mostrar el primer texto con sonido de escribir.
        yield return StartCoroutine(ShowText(firstText, true, false)); // Sonido de escribir, pero sin voz.

        // Pausa más corta entre los textos.
        yield return new WaitForSeconds(pauseBetweenTexts);

        // Borrar el texto antes del siguiente.
        typewriterText.text = "";

        // Mostrar el segundo texto inmediatamente y desvanecerlo.
        yield return StartCoroutine(ShowSecondTextWithFade(secondText));

        // Pausa breve antes de cambiar de escena.
        yield return new WaitForSeconds(0.2f); // Pausa reducida.

        // Realizar fade-out rápido antes de cambiar la escena.
        yield return StartCoroutine(FadeOut());

        // Cambiar a la siguiente escena.
        SceneManager.LoadScene(nextSceneName);

        // Realizar fade-in rápido después de cargar la nueva escena.
        yield return StartCoroutine(FadeIn());
    }

    IEnumerator ShowText(string text, bool playTypingSound, bool playVoiceSound = false)
    {
        string currentText = "";

        for (int i = 0; i < text.Length; i++)
        {
            currentText += text[i];
            typewriterText.text = currentText;

            // Reproducir sonido de escribir solo una vez.
            if (playTypingSound && audioSource && typingSound && !isTypingSoundPlayed)
            {
                isTypingSoundPlayed = true;
                audioSource.PlayOneShot(typingSound);
            }

            // Reproducir sonido de voz solo una vez durante el segundo texto.
            if (playVoiceSound && audioSource && voiceSound && !isVoiceSoundPlayed)
            {
                isVoiceSoundPlayed = true;
                audioSource.PlayOneShot(voiceSound);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        // Resetear las variables para el siguiente texto.
        isTypingSoundPlayed = false;
        isVoiceSoundPlayed = false;
    }

    // Mostrar el segundo texto inmediatamente y desvanecerlo con el mismo efecto que en el script original.
    IEnumerator ShowSecondTextWithFade(string text)
    {
        typewriterText.text = text; // Aparece el segundo texto inmediatamente.
        Color startColor = typewriterText.color;
        float timeElapsed = 0f;

        // Empezamos el desvanecimiento del texto con un efecto de escala
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration);
            typewriterText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            // Efecto de escalado para hacer el texto más llamativo durante el fade-out
            float scale = Mathf.Lerp(1f, 1.2f, timeElapsed / fadeDuration);
            typewriterText.transform.localScale = new Vector3(scale, scale, 1f);

            yield return null;
        }

        // Asegurarse de que el texto se quede completamente invisible
        typewriterText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        typewriterText.transform.localScale = new Vector3(1f, 1f, 1f); // Restablecer escala
    }

    // Asegúrate de que el fade-out también se aplique al panel oscuro (Image).
    IEnumerator FadeOut()
    {
        float timeElapsed = 0f;

        Color panelStartColor = fadeImage.color; // Color inicial del panel.
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration); // De opaco a transparente.
            fadeImage.color = new Color(panelStartColor.r, panelStartColor.g, panelStartColor.b, alpha); // Aplica alpha al panel.

            yield return null;
        }

        // Asegurarse de que el panel quede completamente transparente
        fadeImage.color = new Color(panelStartColor.r, panelStartColor.g, panelStartColor.b, 0f);
    }

    IEnumerator FadeIn()
    {
        float timeElapsed = 0f;

        Color panelStartColor = fadeImage.color; // Color inicial del panel.
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration); // De transparente a opaco.
            fadeImage.color = new Color(panelStartColor.r, panelStartColor.g, panelStartColor.b, alpha); // Aplica alpha al panel.

            yield return null;
        }

        // Asegurarse de que el panel quede completamente opaco
        fadeImage.color = new Color(panelStartColor.r, panelStartColor.g, panelStartColor.b, 1f);
    }
}
