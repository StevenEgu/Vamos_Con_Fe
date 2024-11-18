using UnityEngine;

public class LugarDeColocacion : MonoBehaviour
{
    public bool estaOcupado = false;

    public bool ColocarItem(GameObject item)
    {
        if (!estaOcupado)
        {
            Debug.Log($"Colocando ítem {item.name} en {gameObject.name}.");
            item.transform.position = transform.position; // Posición del lugar
            item.transform.SetParent(transform); // Opcional: Hacer al ítem hijo del lugar
            estaOcupado = true;
            return true;
        }
        else
        {
            Debug.LogWarning($"Lugar {gameObject.name} ya está ocupado.");
            return false;
        }
    }
}
