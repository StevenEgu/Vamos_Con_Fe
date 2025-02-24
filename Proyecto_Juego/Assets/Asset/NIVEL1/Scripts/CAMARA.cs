using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Necesario para el Image (fade)

public class CAMARA : MonoBehaviour
{
    public GameObject target;  // Referencia al jugador o el objetivo de la c�mara
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

    // Para el fade de transici�n
    public Image fadeImage;  // Imagen que se usa para el fade (debe ser un Image con un color negro o blanco completamente opaco)
    public float fadeSpeed = 2f;  // Velocidad del fade

    void Awake()
    {
        posX = target_poseX + derechaMax;
        posY = target_poseY + alturaMin;
        transform.position = new Vector3(posX, posY, -1);  // Inicializa la c�mara en una posici�n
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

        // Aqu� ya est� completamente negro, espera unos instantes si lo deseas
        yield return new WaitForSeconds(0.2f);  // Peque�a pausa (puedes ajustar este tiempo)

        fadeImage.gameObject.SetActive(false);  // Desactiva el fadeImage despu�s de la transici�n
    }

    // Coroutine para el fade en
    private IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);  // Aseg�rate de que el fadeImage est� activo

        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);  // Desactiva el fadeImage despu�s del fade
    }

    // M�todo para realizar el teletransporte
    public void Teleport(GameObject targetLocation)
    {
        StartCoroutine(FadeOut());  // Inicia el fade de salida
        target.transform.position = targetLocation.transform.position;  // Teletransporta al jugador
        StartCoroutine(FadeIn());  // Inicia el fade de entrada despu�s del teletransporte
    }

    void Update()
    {
        Move_Cam();
    }
}

