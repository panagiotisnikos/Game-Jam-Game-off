using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Fields presented in the Inspector
    public int maxLives = 6;
    private int currentLives;
    private int sceneIndex = 1;
    private TrackDistance trackDistance;
    public LevelLoaderController lvlLoader;
    public HUDMenuUIController hudMenuController; // handles functionality in the UI
    public GameObject victoryCanvas;
    public float leveltime; //Time required to finish the level
    bool timeIsRunning; //Checks if timer is still running
    public EnemyManager enemymanager;
    public float enemy_interval;    //Time inbetweeen enemy spawns
    float time_interval;
    public SoundManager soundmanager;

    private void Start()
    {
        currentLives = maxLives;
        trackDistance = GetComponent<TrackDistance>();
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
        // Initialize dependencies with HUD Menu Controller
        // we use methods for encapsulation - we don't directly open the field => fileds private
        // we access them through methods
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        hudMenuController.SetLvlStartText("Lvl " + sceneIndex);
        hudMenuController.SetLvlEndText("Lvl " + (sceneIndex + 1));

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
            // distance requires normalization because the sprite doesn't have the same distance or mesurment with the actual distance in gameplay
            float normalized = Mathf.Clamp01(trackDistance.GetDistance() / trackDistance.GetMaxDistance());
            hudMenuController.NavigationMovement(normalized);

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

        // Debug.Log("Lives left: " + currentLives + "/" + maxLives);

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
        Debug.Log("Calling LoadLevel NOW!");
        lvlLoader.LoadLevel("GameOver");
    }
    private void WinGame()
    {
        Debug.Log("VICTORY");
        Time.timeScale = 0f;
        soundmanager.music.Stop();
        soundmanager.ambience.Stop();
        soundmanager.WinSound();


        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
        }
    }
    public int GetCurrentLives()
    {
        return currentLives;
    }
}
