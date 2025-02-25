using UnityEngine;

public class SonidoAlColisionar : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Referencia al AudioSource
    [SerializeField] private string tagDelObjeto = "Player"; // Etiqueta del objeto que va a colisionar

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Verifica si el objeto que entra en el Trigger tiene la etiqueta correcta
        if (collider.gameObject.CompareTag(tagDelObjeto))
        {
            // Reproduce el sonido si el objeto tiene la etiqueta correcta
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); // Reproduce el sonido si no está ya sonando
            }
        }
    }
}
