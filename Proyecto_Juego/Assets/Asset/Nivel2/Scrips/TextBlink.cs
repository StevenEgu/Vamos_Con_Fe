using UnityEngine;
using TMPro;  // Necesario para trabajar con TextMesh Pro
using System.Collections;  // Necesario para usar IEnumerator

public class TextBlink : MonoBehaviour
{
    public TextMeshProUGUI textMesh;  // El componente de texto al que le vamos a cambiar el color
    public Color color1 = Color.red;  // Color cuando está activo
    public Color color2 = Color.white; // Color cuando está inactivo
    public float blinkSpeed = 1f;  // Velocidad del parpadeo

    private void Start()
    {
        if (textMesh != null)
        {
            StartCoroutine(BlinkTextColor());
        }
    }

    // Coroutine para hacer parpadear el color del texto
    private IEnumerator BlinkTextColor()
    {
        while (true)  // Esto hará que el parpadeo continúe indefinidamente
        {
            textMesh.color = color1;  // Cambia al primer color
            yield return new WaitForSeconds(blinkSpeed);  // Espera un tiempo
            textMesh.color = color2;  // Cambia al segundo color
            yield return new WaitForSeconds(blinkSpeed);  // Espera un tiempo
        }
    }
}
