using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    // Referencias para el panel, los botones y el video
    public GameObject panelGenerador;
    public Button interruptor1, interruptor2, interruptor3, interruptor4, interruptor5;
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    // Sprites para los estados On y Off
    public Sprite spriteOn;
    public Sprite spriteOff;

    // Estados de los interruptores
    private bool estadoInterruptor1 = false;
    private bool estadoInterruptor2 = false;
    private bool estadoInterruptor3 = false;
    private bool estadoInterruptor4 = false;
    private bool estadoInterruptor5 = false;

    private void Start()
    {
        // Inicializar el panel y el VideoPlayer
        panelGenerador.SetActive(false);
        videoPlayer.Stop();

        // Configurar el RenderTexture si no está asignado
        if (videoPlayer.targetTexture == null)
        {
            RenderTexture renderTexture = new RenderTexture(1920, 1080, 0);
            videoPlayer.targetTexture = renderTexture;
        }

        // Asignar el RenderTexture al RawImage
        if (rawImage != null)
        {
            rawImage.texture = videoPlayer.targetTexture;
        }

        // Asignar eventos al VideoPlayer para depuración
        videoPlayer.errorReceived += OnVideoError;
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    private void OnDestroy()
    {
        // Liberar el RenderTexture si está asignado
        if (videoPlayer.targetTexture != null)
        {
            videoPlayer.targetTexture.Release();
        }
    }

    private void OnVideoError(VideoPlayer source, string message)
    {
        Debug.LogError($"Error en el VideoPlayer: {message}");
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        Debug.Log("El VideoPlayer está preparado.");
    }

    public void AbrirPanel()
    {
        panelGenerador.SetActive(true);
    }

    // Métodos para cambiar el estado de los interruptores
    public void CambiarEstadoInterruptor1() => CambiarEstadoInterruptor(ref estadoInterruptor1, interruptor1);
    public void CambiarEstadoInterruptor2() => CambiarEstadoInterruptor(ref estadoInterruptor2, interruptor2);
    public void CambiarEstadoInterruptor3() => CambiarEstadoInterruptor(ref estadoInterruptor3, interruptor3);
    public void CambiarEstadoInterruptor4() => CambiarEstadoInterruptor(ref estadoInterruptor4, interruptor4);
    public void CambiarEstadoInterruptor5() => CambiarEstadoInterruptor(ref estadoInterruptor5, interruptor5);

    private void CambiarEstadoInterruptor(ref bool estado, Button boton)
    {
        estado = !estado;
        Debug.Log($"Interruptor cambiado: {boton.name}, Estado: {estado}");

        if (boton.image != null)
        {
            boton.image.sprite = estado ? spriteOn : spriteOff;
        }
        else
        {
            Debug.LogError($"El botón {boton.name} no tiene un componente Image asignado.");
        }

        RevisarGenerador();
    }

    private void RevisarGenerador()
    {
        int interruptoresEncendidos = 0;

        if (estadoInterruptor1) interruptoresEncendidos++;
        if (estadoInterruptor2) interruptoresEncendidos++;
        if (estadoInterruptor3) interruptoresEncendidos++;

        if (estadoInterruptor4 || estadoInterruptor5)
        {
            DesactivarGenerador();
            return;
        }

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
        if (!videoPlayer.isPrepared)
        {
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += (source) => videoPlayer.Play();
        }
        else if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }

        Debug.Log("¡Generador Activado!");
    }

    private void DesactivarGenerador()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }

        Debug.Log("Generador Desactivado");
    }
}
