using UnityEngine;

public class TrackDistance : MonoBehaviour
{
    [Header("References")]
    public GameManager gameManager; // Σύρε εδώ τον GameManager από τη σκηνή

    [Header("Settings")]
    public float forwardSpeed = 10.0f; 

    [Header("Info (Read Only)")]
    [SerializeField] private float currentDistance = 0f;
    [SerializeField] private float maxDistance = 0f; // Πού είναι το νησί;
    
    private float startingTime; 

    void Start()
    {

        if (gameManager != null)
        {
            startingTime = gameManager.leveltime;
            
            maxDistance = startingTime * forwardSpeed;
        }
        else
        {
            Debug.LogError("TrackDistance:cant find gamemanager!");
        }
    }

    void Update()
    {
        if (gameManager != null)
        {

            float timePassed = startingTime - gameManager.leveltime;


            currentDistance = timePassed * forwardSpeed;


            currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);

            // debug
            Debug.Log("Distance: " + (int)currentDistance + "m / " + (int)maxDistance + "m");
        }
    }

    public float GetDistance()
    {
        return currentDistance;
    }
    
    public float GetMaxDistance()
    {
        return maxDistance;
    }
    
}
