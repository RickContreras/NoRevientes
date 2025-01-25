using UnityEngine;
public class Crecimiento : MonoBehaviour 
{
    public float scaleIncreaseAmount = 0.2f; // Cantidad de aumento de la escala
    public float scaleDecreaseAmount = 0.2f; // Cantidad de disminuci�n de la escala
    public float maxScale = 1.5f; // Tama�o m�ximo del c�rculo
    private void OnCollisionEnter2D(Collision2D collision)
{
    // Verifica si el objeto con el que colision� tiene un PolygonCollider2D y la etiqueta "Triangle"
    if (collision.gameObject.CompareTag("Triangle"))
    {
        print("Incremento de escala");
            // Agranda el c�rculo aumentando su escala (radio)
            Vector3 newScale = transform.localScale + new Vector3(scaleIncreaseAmount, scaleIncreaseAmount, 0);
        if (newScale.x <= maxScale && newScale.y <= maxScale)
        {
            transform.localScale = newScale;
        }
        else
        {
            transform.localScale = new Vector3(maxScale, maxScale, 0);
        }
        Destroy(collision.gameObject);
    }
    if (collision.gameObject.CompareTag("Square"))
    {
            print("Disminuci�n de escala");
            transform.localScale -= new Vector3(scaleDecreaseAmount, scaleDecreaseAmount, 0);
        if (transform.localScale.x < 0.1f || transform.localScale.y < 0.1f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
        Destroy(collision.gameObject);
    }
}
}