using UnityEngine;

public class SharkLogic : MonoBehaviour
{
    public float speed = 700f; // shark movement speed.
    private Rigidbody rb; // Reference to player's Rigidbody.
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        rb.AddForce(speed, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shark: Collision with Player");
            gm.LoseOneLife();
            Destroy(gameObject);
        }

        if (other.CompareTag("OutOfBounds"))
        {
            Debug.Log("Enemy left");
            Destroy(gameObject);
        }

    }


    // ¨Κ: Το έκανα comment out - Μήπως χρειαστεί
    /*void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Enemy Shark left");
            Destroy(gameObject);
        }
    }*/


    // Update is called once per frame
    void Update()
    {

    }
}
