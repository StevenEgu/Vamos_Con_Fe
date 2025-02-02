using UnityEngine;
using UnityEngine.UI;

public class BotonYObjeto : MonoBehaviour
{
    public Button boton;           // Referencia al botón que se va a hacer clic
    public GameObject objeto;      // Referencia al GameObject que se va a encender o apagar

    void Start()
    {
        // Asegúrate de que el botón tenga asignada la función OnClick
        if (boton != null)
        {
            boton.onClick.AddListener(OnBotonClickeado);
        }
    }

    void OnBotonClickeado()
    {
        // Al hacer clic en el botón, desactivar el botón y activar el GameObject
        if (boton != null)
        {
            boton.gameObject.SetActive(false);  // Desactiva el botón
        }

        if (objeto != null)
        {
            objeto.SetActive(true);  // Activa el GameObject
        }
    }
}
