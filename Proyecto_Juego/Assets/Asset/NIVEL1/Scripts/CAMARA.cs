using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Necesario para el Image (fade)

public class CAMARA : MonoBehaviour
{
    public GameObject target;  // Referencia al jugador o el objetivo de la cámara
    public float derechaMax;
    public float izquierdaMax;
    public float alturaMax;
    public float alturaMin;
    public float speed;

    private float target_poseX;
    private float target_poseY;
    private float posX;
    private float posY;
    public bool encendida = true;

    // Para el fade de transición
    public Image fadeImage;  // Imagen que se usa para el fade (debe ser un Image con un color negro o blanco completamente opaco)
    public float fadeSpeed = 2f;  // Velocidad del fade

    void Awake()
    {
        posX = target_poseX + derechaMax;
        posY = target_poseY + alturaMin;
        transform.position = new Vector3(posX, posY, -1);  // Inicializa la cámara en una posición
    }

    void Move_Cam()
    {
        if (encendida)
        {
            if (target)
            {
                target_poseX = target.transform.position.x;
                target_poseY = target.transform.position.y;

                if (target_poseX > derechaMax && target_poseX < izquierdaMax)
                {
                    posX = target_poseX;
                }

                if (target_poseY < alturaMax && target_poseY > alturaMin)
                {
                    posY = target_poseY;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed * Time.deltaTime);
        }
    }

    // Coroutine para el fade
    private IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);  // Activa el fadeImage

        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        // Aquí ya está completamente negro, espera unos instantes si lo deseas
        yield return new WaitForSeconds(0.2f);  // Pequeña pausa (puedes ajustar este tiempo)

        fadeImage.gameObject.SetActive(false);  // Desactiva el fadeImage después de la transición
    }

    // Coroutine para el fade en
    private IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);  // Asegúrate de que el fadeImage esté activo

        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);  // Desactiva el fadeImage después del fade
    }

    // Método para realizar el teletransporte
    public void Teleport(GameObject targetLocation)
    {
        StartCoroutine(FadeOut());  // Inicia el fade de salida
        target.transform.position = targetLocation.transform.position;  // Teletransporta al jugador
        StartCoroutine(FadeIn());  // Inicia el fade de entrada después del teletransporte
    }

    void Update()
    {
        Move_Cam();
    }
}

