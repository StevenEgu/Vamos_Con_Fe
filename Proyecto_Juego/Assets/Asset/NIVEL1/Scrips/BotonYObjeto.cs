using UnityEngine;
using UnityEngine.UI;

public class BotonYObjeto : MonoBehaviour
{
    public Button boton;           // Referencia al bot�n que se va a hacer clic
    public GameObject objeto;      // Referencia al GameObject que se va a encender o apagar

    void Start()
    {
        // Aseg�rate de que el bot�n tenga asignada la funci�n OnClick
        if (boton != null)
        {
            boton.onClick.AddListener(OnBotonClickeado);
        }
    }

    void OnBotonClickeado()
    {
        // Al hacer clic en el bot�n, desactivar el bot�n y activar el GameObject
        if (boton != null)
        {
            boton.gameObject.SetActive(false);  // Desactiva el bot�n
        }

        if (objeto != null)
        {
            objeto.SetActive(true);  // Activa el GameObject
        }
    }
}
