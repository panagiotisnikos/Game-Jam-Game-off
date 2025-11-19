using UnityEngine;

public class VictoryStats : MonoBehaviour
{
    public static VictoryStats Instance;

    [Header("References")]
    public GameManager gameManager;
    public TrackDistance trackDistance;

    [Header("Final Results (Read Only)")]
    public float finalScoreDistance; // Το σκορ σε μέτρα
    public int finalLives;           // Πόσες ζωές έμειναν
    public int starsEarned;         
    public bool isNewHighScore;      // Αν έκανε high score

    [Header("Settings")]
    public string highScoreKey = "HighScore"; 

    void Awake()
    {
  
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Αυτόματη εύρεση αν είναι στο ίδιο αντικείμενο
        if (gameManager == null) gameManager = GetComponent<GameManager>();
        if (trackDistance == null) trackDistance = GetComponent<TrackDistance>();
    }

    public void CalculateFinalStats()
    {
        if (gameManager == null)
        {
            Debug.LogError("VictoryStats: cant find gamemanager!");
            return;
        }


        finalLives = gameManager.GetCurrentLives();
        
        if (trackDistance != null)
            finalScoreDistance = trackDistance.GetDistance();
        else
            finalScoreDistance = 0f;


        float percentage = (float)finalLives / gameManager.maxLives;
        
        CheckHighScore();

        Debug.Log($"VICTORY STATS: Distance: {finalScoreDistance}m | Lives: {finalLives} | Stars: {starsEarned}");
    }

    private void CheckHighScore()
    {
        float currentHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);

        if (finalScoreDistance > currentHighScore)
        {
            isNewHighScore = true;
            PlayerPrefs.SetFloat(highScoreKey, finalScoreDistance);
            PlayerPrefs.Save();
            Debug.Log("NEW HIGH SCORE SAVED!");
        }
        else
        {
            isNewHighScore = false;
        }
    }
}