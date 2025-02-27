using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public Transform player; // Asigna el jugador desde el Inspector
    public AudioSource audioSource;
    public float maxDistance = 10f; // Distancia máxima donde se escuchará el sonido
    public float minVolume = 0.1f; // Volumen mínimo cuando el jugador está lejos
    public float maxVolume = 1f; // Volumen máximo cuando el jugador está cerca

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
