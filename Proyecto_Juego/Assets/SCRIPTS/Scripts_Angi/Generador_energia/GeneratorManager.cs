using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    // Referencias para el panel, los botones y el video
    public GameObject panelGenerador;
    public Button interruptor1, interruptor2, interruptor3, interruptor4, interruptor5;
    public VideoPlayer videoPlayer;
    public RawImage rawImage; // Asegúrate de tener el RawImage en la escena

    // Sprites para los estados On y Off
    public Sprite spriteOn;
    public Sprite spriteOff;

    // Estados de los interruptores
    private bool estadoInterruptor1 = false;
    private bool estadoInterruptor2 = false;
    private bool estadoInterruptor3 = false;
    private bool estadoInterruptor4 = false;
    private bool estadoInterruptor5 = false;

    void Start()
    {
        // Inicializar el panel y el VideoPlayer
        panelGenerador.SetActive(false);
        videoPlayer.Stop();

        // Asegúrate de que el VideoPlayer esté configurado para reproducir en el RawImage
        if (videoPlayer.targetTexture == null)
        {
            // Crear un RenderTexture y asignarlo al VideoPlayer si no está configurado
            RenderTexture renderTexture = new RenderTexture(1920, 1080, 0); // Ajusta la resolución si es necesario
            videoPlayer.targetTexture = renderTexture;
        }

        // Asignar el RenderTexture al RawImage para que el video se vea
        rawImage.texture = videoPlayer.targetTexture;
    }

    public void AbrirPanel()
    {
        panelGenerador.SetActive(true);
    }

    // Métodos públicos para que Unity los reconozca en OnClick
    public void CambiarEstadoInterruptor1()
    {
        CambiarEstadoInterruptor(ref estadoInterruptor1, interruptor1);
    }

    public void CambiarEstadoInterruptor2()
    {
        CambiarEstadoInterruptor(ref estadoInterruptor2, interruptor2);
    }

    public void CambiarEstadoInterruptor3()
    {
        CambiarEstadoInterruptor(ref estadoInterruptor3, interruptor3);
    }

    public void CambiarEstadoInterruptor4()
    {
        CambiarEstadoInterruptor(ref estadoInterruptor4, interruptor4);
    }

    public void CambiarEstadoInterruptor5()
    {
        CambiarEstadoInterruptor(ref estadoInterruptor5, interruptor5);
    }

    private void CambiarEstadoInterruptor(ref bool estado, Button boton)
    {
        estado = !estado; // Cambiar el estado
        Debug.Log($"Interruptor cambiado: {boton.name}, Estado: {estado}");

        // Verificar si el botón tiene un componente Image antes de asignar el sprite
        if (boton.image != null)
        {
            boton.image.sprite = estado ? spriteOn : spriteOff;
        }
        else
        {
            Debug.LogError($"El botón {boton.name} no tiene un componente Image asignado.");
        }

        RevisarGenerador(); // Revisar si el generador debe activarse
    }

    private void RevisarGenerador()
    {
        int interruptoresEncendidos = 0;

        // Contamos cuántos de los interruptores 1, 2 y 3 están encendidos
        if (estadoInterruptor1) interruptoresEncendidos++;
        if (estadoInterruptor2) interruptoresEncendidos++;
        if (estadoInterruptor3) interruptoresEncendidos++;

        // Verificar si los interruptores 4 y 5 están apagados
        if (estadoInterruptor4 || estadoInterruptor5)
        {
            DesactivarGenerador(); // Desactivar si 4 o 5 están encendidos
            return;
        }

        // Si 3 interruptores de los primeros 3 están encendidos y 4 y 5 están apagados
        if (interruptoresEncendidos == 3)
        {
            ActivarGenerador();
        }
        else
        {
            DesactivarGenerador();
        }
    }

    private void ActivarGenerador()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play(); // Asegúrate de que el video comience a reproducirse
            Debug.Log("¡Generador Activado!");
        }
    }

    private void DesactivarGenerador()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop(); // Detener el video si no es necesario
            Debug.Log("Generador Desactivado");
        }
    }
}
