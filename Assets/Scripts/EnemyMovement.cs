using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 100f; // Set player's movement speed.
    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        rb.AddForce(0,0,-speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("We hit an enemy");
            Destroy(gameObject);
        }
       
    }
    void OnTriggerExit(Collider other)
    {
            if (other.CompareTag("Wall"))
        {
            Debug.Log("Enemy left");
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
