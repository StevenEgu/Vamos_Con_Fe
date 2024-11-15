using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Angi : MonoBehaviour
{
    public Sprite itemIcon;  // El ícono del ítem

    public void Use()
    {
        Debug.Log("Usando el ítem: " + gameObject.name);
    }
}