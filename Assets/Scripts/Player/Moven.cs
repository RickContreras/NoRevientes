using UnityEngine;
using System.Collections;

public class Moven : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float rampSpeed = 50f;
    private Rigidbody2D rb;
    private bool onRamp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        print(rb.linearVelocity);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (onRamp)
        {
            rb.linearVelocity = movement * rampSpeed;
        }
        else
        {
            print("Normal speed");
            rb.linearVelocity = movement * normalSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onRamp = true;
            StopCoroutine("RampExitDelay");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            StartCoroutine("RampExitDelay");
        }
    }

    IEnumerator RampExitDelay()
    {
        yield return new WaitForSeconds(0.5f);
        onRamp = false;
    }
}