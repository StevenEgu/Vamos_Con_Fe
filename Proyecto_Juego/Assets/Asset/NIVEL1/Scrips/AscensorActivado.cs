using UnityEngine;

public class AscensorActivado : MonoBehaviour
{
    public GameObject panel1;  // Primer panel
    public GameObject panel2;  // Segundo panel
    public GameObject objetoParaActivar;  // El GameObject que se activar�

    private bool panel1Abierto = false;  // Estado del primer panel
    private bool panel2Abierto = false;  // Estado del segundo panel

    void Update()
    {
        // Verificar si ambos paneles est�n abiertos
        if (panel1Abierto && panel2Abierto)
        {
            // Activar el GameObject cuando ambos paneles est�n abiertos
            if (objetoParaActivar != null)
            {
                objetoParaActivar.SetActive(true);  // Activa el GameObject
            }
        }
    }

    // M�todo para llamar cuando el primer panel se abre
    public void AbrirPanel1()
    {
        panel1Abierto = true;
        ComprobarYActivarObjeto();
    }

    // M�todo para llamar cuando el segundo panel se abre
    public void AbrirPanel2()
    {
        panel2Abierto = true;
        ComprobarYActivarObjeto();
    }

    // M�todo que comprueba si ambos paneles est�n abiertos y activa el GameObject
    private void ComprobarYActivarObjeto()
    {
        if (panel1Abierto && panel2Abierto)
        {
            if (objetoParaActivar != null)
            {
                objetoParaActivar.SetActive(true);  // Activa el GameObject
            }
        }
    }

    // Si necesitas desactivar el GameObject m�s tarde, puedes hacerlo con este m�todo
    public void DesactivarObjeto()
    {
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(false);  // Desactiva el GameObject
        }
    }
}
