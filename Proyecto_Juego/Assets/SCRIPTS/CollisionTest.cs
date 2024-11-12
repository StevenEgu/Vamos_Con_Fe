using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.name);
    }
}