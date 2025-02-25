using UnityEngine;
using UnityEngine.UI;

public class CollectButton : MonoBehaviour
{
    public SliderControl sliderControl; // Referencia al controlador del slider

    // M�todo que se llama al presionar el bot�n
    public void OnButtonPress()
    {
        // Llamamos al m�todo OnObjectCollected del SliderControl
        sliderControl.OnObjectCollected();
    }
}
