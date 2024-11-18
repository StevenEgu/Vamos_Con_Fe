using UnityEngine;

public class LugarDeColocacion : MonoBehaviour
{
    public bool estaOcupado = false;

    public bool ColocarItem(GameObject item)
    {
        if (!estaOcupado)
        {
            Debug.Log($"Colocando �tem {item.name} en {gameObject.name}.");
            item.transform.position = transform.position; // Posici�n del lugar
            item.transform.SetParent(transform); // Opcional: Hacer al �tem hijo del lugar
            estaOcupado = true;
            return true;
        }
        else
        {
            Debug.LogWarning($"Lugar {gameObject.name} ya est� ocupado.");
            return false;
        }
    }
}
