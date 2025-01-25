using UnityEngine;
using System.Collections;

public class Impulso : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float rampSpeed = 100f;
    public float exitImpulseForce = 10000f; // Fuerza del impulso al salir de la rampa
    private Rigidbody2D rb;
    private bool onRamp = false;
    private Vector2 rampExitDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener el vector velocidad del rigidbody
        Vector2 currentVelocity = rb.linearVelocity;
        Vector2 movement = currentVelocity.normalized;

        if (onRamp)
        {
            rb.linearVelocity = movement * rampSpeed;
        }
        else
        {
            rb.linearVelocity = movement * normalSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            print("On ramp");
            onRamp = true;
            rampExitDirection = collision.transform.right; // Dirección X del objeto de colisión
            StopCoroutine("RampExitDelay");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            print("Exit ramp");
            StartCoroutine("RampExitDelay");
        }
    }

    IEnumerator RampExitDelay()
    {   

        print(rb.linearVelocity);
        ApplyExitImpulse();
        print(rb.linearVelocity);
        yield return new WaitForSeconds(0.2f);// Duración más corta para un impulso más intenso
        print(rb.linearVelocity);
        onRamp = false;
    }

    void ApplyExitImpulse()
    {
        Vector2 impulse = new Vector2(rampExitDirection.x * exitImpulseForce, 0);
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }
}