using UnityEngine;

public class BubblePhysics : MonoBehaviour
{
    [Header("Bubble Movement Parameters")]
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private float pushRadius = 2f;
    [SerializeField] private float dampingFactor = 0.95f;

    private Rigidbody2D rb;
    private Vector2 velocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale=0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        float distance = Vector2.Distance(mouseWorldpos, transform.position);

        if (distance < pushForce)
        {
            Vector2 pushDirection = ((Vector2)transform.position - mouseWorldpos).normalized;

            float pushIntensity = 1f - (distance / pushForce);
             
            velocity = pushDirection * pushIntensity *pushForce;

        }

        velocity *= dampingFactor;

        rb.linearVelocity = velocity;
    }
}
