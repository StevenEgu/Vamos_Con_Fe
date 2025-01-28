using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTRUIR : MonoBehaviour
{
    public GameObject GameObject;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        GameObject.SetActive(false);
    }
}
