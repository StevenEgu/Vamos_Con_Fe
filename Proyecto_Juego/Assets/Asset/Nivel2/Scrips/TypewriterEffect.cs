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
    public float pauseBetweenTexts = 1.0f; // Pausa entre textos.
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

        // Pausa entre los textos.
        yield return new WaitForSeconds(pauseBetweenTexts);

        // Borrar el texto antes del siguiente.
        typewriterText.text = "";

        // Mostrar el segundo texto con sonido de voz.
        yield return StartCoroutine(ShowText(secondText, false, true)); // Solo sonido de voz.

        // Pausa antes de cambiar de escena.
        yield return new WaitForSeconds(pauseBetweenTexts);

        // Realizar fade-out antes de cambiar la escena.
        yield return StartCoroutine(FadeOut());

        // Cambiar a la siguiente escena.
        SceneManager.LoadScene(nextSceneName);

        // Realizar fade-in después de cargar la nueva escena.
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
                Debug.Log("Reproduciendo sonido de escribir...");
            }

            // Reproducir sonido de voz solo una vez durante el segundo texto.
            if (playVoiceSound && audioSource && voiceSound && !isVoiceSoundPlayed)
            {
                isVoiceSoundPlayed = true;
                audioSource.PlayOneShot(voiceSound);
                Debug.Log("Reproduciendo sonido de voz...");
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        // Detener el sonido de escribir una vez que se termine el primer texto.
        if (isTypingSoundPlayed)
        {
            audioSource.Stop(); // Detener el audio de escribir.
            Debug.Log("Sonido de escribir detenido.");
        }

        // Resetear las variables para el siguiente texto.
        isTypingSoundPlayed = false;
        isVoiceSoundPlayed = false;
    }

    IEnumerator FadeOut()
    {
        float timeElapsed = 0f;

        // Empezamos con la opacidad del panel a 0 (totalmente transparente).
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration));
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f); // Asegurarnos de que quede 100% opaco al final.
    }

    IEnumerator FadeIn()
    {
        float timeElapsed = 0f;

        // Empezamos con la opacidad del panel a 1 (totalmente opaco).
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration));
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f); // Asegurarnos de que quede totalmente transparente al final.
    }
}
