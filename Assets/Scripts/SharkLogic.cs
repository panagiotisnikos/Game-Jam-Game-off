using UnityEngine;

public class SharkLogic : MonoBehaviour
{
    public float speed = 700f; // shark movement speed.
    private Rigidbody rb; // Reference to player's Rigidbody.
    public GameManager gm;
    public SoundManager soundmanager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundmanager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        rb.AddForce(speed, 0, 0);
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

    }


    // ��: �� ����� comment out - ����� ���������
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
