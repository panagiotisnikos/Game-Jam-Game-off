using UnityEngine;

public class islandAnimation : MonoBehaviour
{

    public float islandAnimationSpeed = 3f;






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0f, -1f) * islandAnimationSpeed * Time.deltaTime;

        if (transform.position.z < -30f)
        {
            Destroy(gameObject);
        }

    }
}
