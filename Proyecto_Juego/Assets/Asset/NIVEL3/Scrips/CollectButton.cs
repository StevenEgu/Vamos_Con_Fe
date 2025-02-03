using UnityEngine;
using UnityEngine.UI;

public class CollectButton : MonoBehaviour
{
    public SliderControl sliderControl; // Referencia al controlador del slider

    // Método que se llama al presionar el botón
    public void OnButtonPress()
    {
        // Llamamos al método OnObjectCollected del SliderControl
        sliderControl.OnObjectCollected();
    }
}
