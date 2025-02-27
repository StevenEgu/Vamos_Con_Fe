using UnityEngine;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour
{
    public Slider slider;  // Referencia al Slider
    public AudioSource audioSource;  // Referencia al AudioSource
    public float volume = 0.5f;  // Volumen del sonido (ajustable)

    private void Start()
    {
        // Aseg�rate de que el slider tenga un evento para cuando su valor cambie
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // Esta funci�n se llama cada vez que el valor del slider cambia
    private void OnSliderValueChanged(float value)
    {
        // Reproducir el sonido cada vez que el slider cambia
        PlaySound();
    }

    // M�todo para reproducir el sonido
    private void PlaySound()
    {
        // Verifica si el audio no est� reproduci�ndose ya, para evitar duplicados
        if (!audioSource.isPlaying)
        {
            audioSource.volume = volume;  // Ajusta el volumen
            audioSource.Play();  // Reproduce el sonido
        }
    }
}
