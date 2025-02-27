using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public Transform player; // Asigna el jugador desde el Inspector
    public AudioSource audioSource;
    public float maxDistance = 10f; // Distancia m�xima donde se escuchar� el sonido
    public float minVolume = 0.1f; // Volumen m�nimo cuando el jugador est� lejos
    public float maxVolume = 1f; // Volumen m�ximo cuando el jugador est� cerca

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        audioSource.loop = true; // Para que el sonido sea continuo
        audioSource.Play(); // Reproduce el sonido al inicio
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float volume = Mathf.Lerp(maxVolume, minVolume, distance / maxDistance);
        audioSource.volume = Mathf.Clamp(volume, minVolume, maxVolume);
    }
}
