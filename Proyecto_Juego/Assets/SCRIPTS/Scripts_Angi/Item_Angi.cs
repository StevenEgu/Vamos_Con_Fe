using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Angi : MonoBehaviour
{
    public Sprite itemIcon;  // El �cono del �tem

    public void Use()
    {
        Debug.Log("Usando el �tem: " + gameObject.name);
    }
}