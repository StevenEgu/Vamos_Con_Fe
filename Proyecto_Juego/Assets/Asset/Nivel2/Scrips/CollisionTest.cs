using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisi�n detectada con: " + other.name);
    }
}