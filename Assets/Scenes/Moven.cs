using UnityEngine;

public class Moven : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float rampSpeed = 100f;
    private Rigidbody2D rb;
    private bool onRamp = false;

    void Start()
    {
        // Intentar obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        // Si no est� presente, agregarlo din�micamente
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (onRamp)
        {
            rb.linearVelocity = movement * rampSpeed;
            Debug.Log("Acelerando: " + rb.linearVelocity);
        }
        else
        {
            rb.linearVelocity = movement * normalSpeed;
            Debug.Log("Velocidad normal: " + rb.linearVelocity);
        }
    }

    void OntriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onRamp = true;
            Debug.Log("En la rampa - Acelerando!");
        }
    }

    void OnTriggerExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onRamp = false;
            Debug.Log("Fuera de la rampa - Velocidad normal.");
        }
    }
}
