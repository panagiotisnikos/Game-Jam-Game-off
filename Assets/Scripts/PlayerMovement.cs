using UnityEngine;

// Controls player movement and rotation.
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f; // For use inside this script (FixedUpdate)
    public float speed_normal = 5.0f; // Set player's movement speed
    public float speed_debuff = 3.0f; // entered seaweed area debuff
    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        speed = speed_normal; // Αρχικοποίηση τιμής ταχύτητας
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        //Move player OLD method
        // Move player based on vertical input.
        /*float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input.
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement2 = transform.right * moveHorizontal * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement2);*/


        //Move player NEW method
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        moveDirection = moveDirection.normalized;
        rb.MovePosition(rb.position + (moveDirection * speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seaweed"))
        { 
            speed = speed_debuff;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Seaweed"))
        {
            speed = speed_normal;
        }
    }
}