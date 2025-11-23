using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Fields presented in the Inspector
    public int maxLives = 6;
    private int currentLives;
    public HUDMenuUIController hudMenuController; // handles functionality in the UI
    // public TextMeshProUGUI livesText;   // text object used to display lives
    public float leveltime; //Time required to finish the level
    bool timeIsRunning; //Checks if timer is still running
    public EnemyManager enemymanager;
    public float enemy_interval;    //Time inbetweeen enemy spawns
    float time_interval;
    public SoundManager soundmanager;

    private void Start()
    {
        currentLives = maxLives;
        // Initialize dependencies with HUD Menu Controller
        // we use methods for encapsulation - we don't directly open the field => fileds private
        // we access them through methods
        // hudMenuController.SetLivesText(livesText);

        // Build and show initial lives
        hudMenuController.BuildHearts(maxLives);
        hudMenuController.UpdateLives(currentLives, maxLives);
        timeIsRunning = true;
    }

    void FixedUpdate()
    {
        if (timeIsRunning == true) //Timer runs out
        {
            leveltime -= Time.deltaTime;
            time_interval += Time.deltaTime;
            if (time_interval >= enemy_interval)
            {
                time_interval = 0;
                enemymanager.SpawnRock();   //Calls method to spawn an enemy
                enemymanager.shark_spawn(); // Testing the shark enemy
                enemymanager.seaweed_spawn();
            }
            if (leveltime <= 0)
            {
                timeIsRunning = false;
                Debug.Log("You survived!");
                WinGame();
            }
        }
    }

    public void LoseOneLife()
    {
        currentLives -= 1;
        if (currentLives < 0) currentLives = 0;

        Debug.Log("Lives left: " + currentLives + "/" + maxLives);

        // Play animation for hit in life
        hudMenuController.PlayLoseLifeEffect(currentLives);
        // update values 
        hudMenuController.UpdateLives(currentLives, maxLives);

        if (currentLives <= 0)
        {
            soundmanager.BottleBreak();
            EndGame();
        }
        else
        {
            soundmanager.BottleHit();
        }
    }

    private void EndGame()
    {
        Debug.Log("DEATH");
        Time.timeScale = 0f;
        soundmanager.EndMusic();
    }
    private void WinGame()
    {
        Debug.Log("DEATH");
        Time.timeScale = 0f;
    }
    public int GetCurrentLives()
    {
        return currentLives;
    }
}
