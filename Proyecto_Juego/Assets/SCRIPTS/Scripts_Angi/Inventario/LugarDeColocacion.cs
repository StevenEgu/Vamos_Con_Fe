using UnityEngine;
using System.Collections;  // Aseg�rate de incluir esto para usar corutinas

public class LugarDeColocacion : MonoBehaviour
{
    public bool estaOcupado = false;
    public GameObject popUp; // Referencia al pop-up en la escena
    public string codigo = "ABC123"; // C�digo que aparecer� en el pop-up
    public CambiarSprite spriteDeLugar; // Referencia al script CambiarSprite

    private CanvasGroup popUpCanvasGroup; // Referencia al CanvasGroup del pop-up

    private void Start()
    {
        // Aseg�rate de que el pop-up est� desactivado al inicio
        if (popUp != null)
        {
            popUp.SetActive(false);
            popUpCanvasGroup = popUp.GetComponent<CanvasGroup>();  // Obtener el CanvasGroup
        }
    }

    public bool ColocarItem(GameObject item)
    {
        Debug.Log($"Intentando colocar �tem {item.name} en {gameObject.name}.");
        if (!estaOcupado)
        {
            // Coloca el �tem en la posici�n del lugar
            item.transform.position = transform.position;
            item.transform.SetParent(transform); // Opcional: Hacer al �tem hijo del lugar
            estaOcupado = true;

            // Cambia el sprite a un nuevo sprite
            if (spriteDeLugar != null)
            {
                spriteDeLugar.CambiarASpriteNuevo(); // Llama al m�todo para cambiar el sprite
            }

            // Muestra el pop-up y m�s
            if (popUp != null)
            {
                popUp.SetActive(true);
                StartCoroutine(DesvanecerPopUp()); // Inicia el desvanecimiento
            }

            return true; // Devuelve true si todo sali� bien
        }
        else
        {
            Debug.LogWarning($"Lugar {gameObject.name} ya est� ocupado.");
            return false; // Si el lugar ya est� ocupado
        }
    }

    private IEnumerator DesvanecerPopUp()
    {
        if (popUpCanvasGroup == null)
        {
            Debug.LogError("No se ha encontrado el CanvasGroup en el pop-up.");
            yield break;  // Si no hay CanvasGroup, termina la corutina
        }

        float tiempoDesvanecimiento = 6f; // Tiempo en segundos para el desvanecimiento
        float tiempoTranscurrido = 0f;

        // Aseg�rate de que el pop-up est� completamente visible al inicio
        popUpCanvasGroup.alpha = 1f;

        while (tiempoTranscurrido < tiempoDesvanecimiento)
        {
            // Incrementar el tiempo transcurrido
            tiempoTranscurrido += Time.deltaTime;

            // Reducir la opacidad del CanvasGroup
            popUpCanvasGroup.alpha = 1f - (tiempoTranscurrido / tiempoDesvanecimiento);

            yield return null; // Esperar el siguiente frame
        }

        // Asegurarse de que la opacidad sea 0 al final
        popUpCanvasGroup.alpha = 0f;

        // Desactivar el pop-up una vez haya terminado el desvanecimiento
        popUp.SetActive(false);
    }
}
