using UnityEngine;

// Controls player movement and rotation.
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input.
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement2 = transform.right * moveHorizontal * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement2);
    }
}