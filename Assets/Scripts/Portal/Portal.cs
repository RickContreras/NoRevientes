using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform portal2; // La posición de destino (Capsule(1))    

    public static float tiempoNoUso = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time > tiempoNoUso)
        {
            collision.transform.position = portal2.position;
            tiempoNoUso = Time.time + 1;
        }
    }
}
