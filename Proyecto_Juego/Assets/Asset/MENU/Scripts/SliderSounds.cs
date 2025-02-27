using UnityEngine;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour
{
    public Slider slider;  // Referencia al Slider
    public AudioSource audioSource;  // Referencia al AudioSource
    public float volume = 0.5f;  // Volumen del sonido (ajustable)

    private void Start()
    {
        // Asegúrate de que el slider tenga un evento para cuando su valor cambie
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // Esta función se llama cada vez que el valor del slider cambia
    private void OnSliderValueChanged(float value)
    {
        // Reproducir el sonido cada vez que el slider cambia
        PlaySound();
    }

    // Método para reproducir el sonido
    private void PlaySound()
    {
        // Verifica si el audio no está reproduciéndose ya, para evitar duplicados
        if (!audioSource.isPlaying)
        {
            audioSource.volume = volume;  // Ajusta el volumen
            audioSource.Play();  // Reproduce el sonido
        }
    }
}
