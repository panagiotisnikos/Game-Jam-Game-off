using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Apple;

public class SharkLogic : MonoBehaviour
{
    public float speed = 10f; // shark movement speed.
    private Rigidbody rb; // Reference to player's Rigidbody.
    public GameManager gm;
    public SoundManager soundmanager;

    private Vector3 chosen_destination = new Vector3(6.4f, 0, 2f); // testing destination, this refreshes with find_target()
    
    private Quaternion originalRotation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundmanager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        find_target();
        /*
        rb.AddForce(speed, 0, 0);
        */

        originalRotation = transform.localRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shark: Collision with Player");
            gm.LoseOneLife();
            soundmanager.HitShark();    //Plays sound of shark bitting
            Destroy(gameObject);
        }

        if (other.CompareTag("OutOfBounds"))
        {
            Debug.Log("Enemy left");
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            soundmanager.HitShark();
        }

    }


    //   :          comment out -                
    /*void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Enemy Shark left");
            Destroy(gameObject);
        }
    }*/


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, chosen_destination, speed * Time.deltaTime);
        
        animate_shark();


    }

    void find_target()
    {
        int find_side = -1;
        if (transform.position.x < 0)
        {
            find_side = 1;
        }


        chosen_destination = new Vector3(20 * find_side, 0, Random.Range(-6, 5));

        Vector3 direction = chosen_destination - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);

        //chosen_destination = destinations[Random.Range(0, destinations.Length)];
    }

    void animate_shark()
    {
        float tilt = Mathf.Sin(Time.time * 1f) * 2f;
        //transform.localRotation = originalRotation * Quaternion.Euler(0, 0, tilt);

        float wobble = Mathf.Sin(Time.time * 10f) * 5f; // +- 5 μοίρες σε χρόνο time*(scalar)

        // Περιστροφή γύρω από τον άξονα Y (αριστερά/δεξιά) και Z
        transform.localRotation = originalRotation * Quaternion.Euler(0, wobble, tilt);
    }
}
