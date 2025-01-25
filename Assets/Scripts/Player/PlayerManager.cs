using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public float health = 10f;
    public GameObject deathpanel;
    public GameObject body;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health--;

            if (health <= 0)
            {
                Debug.Log("mori");
                Destroy(body);

                deathpanel.SetActive(true);

            }
        }

        


    }

   
    public void retry()
    {
        SceneManager.LoadScene("nivel2");
    }

   


}
