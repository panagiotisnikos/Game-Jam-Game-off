using UnityEngine;

public class SeaweedLogic : MonoBehaviour
{
    public float seaweed_speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, chosen_destination, speed * Time.deltaTime);
        transform.position -= new Vector3(0, 0, seaweed_speed * Time.deltaTime);
    }

}
