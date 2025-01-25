using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class Crecimiento : MonoBehaviour
{
    [Header("Limites de escalamiento")]
    public float maxScale = 1.5f; // Tamaño máximo del círculo
    public float minScale = 0.5f; // Tamaño mínimo del círculo
    [Header("Configuracion del escalamiento")]
    public float scaleAmount = 0.2f; // Cantidad para la escala
    public AnimationCurve scaleCurve; // Curva de escala
    public float timeScaling = 0.5f; // Tiempo de escalamiento
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Aumento de escala
        if (collision.gameObject.CompareTag("Triangle"))
        {
            Vector3 escala = new Vector3(scaleAmount, scaleAmount, 0);
            Vector3 newScale = transform.localScale + escala;
            StartCoroutine(TransicionDeEscalamiento(escala));
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
        //Disminución de escala
        if (collision.gameObject.CompareTag("Square"))
        {
            Vector3 escala = new Vector3(scaleAmount, scaleAmount, 0);
            Vector3 newScale = transform.localScale + escala;
            StartCoroutine(TransicionDeEscalamiento(escala * (-1)));
            transform.localScale -= escala;
            if (transform.localScale.x < 0.1f || transform.localScale.y < 0.1f)
            {
                transform.localScale = new Vector3(minScale, minScale, 0);
            }
            Destroy(collision.gameObject);
        }
    }
    IEnumerator TransicionDeEscalamiento(Vector3 escala)
    {
        Vector3 newScale = transform.localScale + escala;
        Vector3 oldScale = transform.localScale;
        float deltaT = timeScaling/10; // 10 pausas

        for (int i = 0; i <= 10; i++) //El maximo de i es 10
        {
            transform.localScale = Vector3.LerpUnclamped(oldScale, newScale, scaleCurve.Evaluate(i / 10f)); // 10f se refiere al maximo de i
            yield return new WaitForSeconds(deltaT);
        }
    }   
}