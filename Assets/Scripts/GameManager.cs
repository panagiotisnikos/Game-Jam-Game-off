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
    public GameObject islandPrefab;
    private bool islandEndOfLevel = false;
    public float rockInterval = 2.0f;
    public float seaweedInterval = 2.0f;
    public float sharkInterval = 2.0f;
    private float rockTimer;
    private float seaweedTimer;
    private float sharkTimer;
    public bool sharkSpawnAllowed = true;
    public bool rockSpawnAllowed = true;
    public bool seaweedSpawnAllowed = true;


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
        // -1: scenes - mainMenu
        int numberOfScenes = SceneManager.sceneCountInBuildSettings - 1;
        if (sceneIndex + 1 == numberOfScenes)
        {
            hudMenuController.SetLvlEndText("The End");
        }
        else
        {
            hudMenuController.SetLvlEndText("Lvl " + (sceneIndex + 1));
        }

        // Build and show initial lives
        hudMenuController.BuildHearts(maxLives);
        hudMenuController.UpdateLives(currentLives, maxLives);
        timeIsRunning = true;
        enemyTimersInit();

        islandSpawn();
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


            // έλεγχος εχθρών
            enemySpawnManagement();



            if (leveltime <= 0)
            {
                timeIsRunning = false;
                Debug.Log("You survived!");
                WinGame();
            }
            if (leveltime < 3.5f && !islandEndOfLevel)
            {
                islandSpawn();
                islandEndOfLevel = true;
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
        // Debug.Log("Calling LoadLevel NOW!");
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
    private void enemyTimersInit()
    {
        rockTimer = rockInterval;
        sharkTimer = sharkInterval;
        seaweedTimer = seaweedInterval;
    }


    private void enemySpawnManagement()
    {
            if (rockSpawnAllowed)
            {
                rockInterval -= Time.deltaTime;
                if (rockInterval <= 0)
                {
                    enemymanager.SpawnRock();
                    rockInterval = rockTimer;
                }
            }

            if (seaweedSpawnAllowed)
            {
                seaweedInterval -= Time.deltaTime;
                if (seaweedInterval <= 0)
                {
                    enemymanager.seaweed_spawn();
                    seaweedInterval = seaweedTimer;
                }
            }

            if (sharkSpawnAllowed)
            {
                sharkInterval -= Time.deltaTime;
                if (sharkInterval <= 0)
                {
                    enemymanager.shark_spawn();
                    sharkInterval = sharkTimer;
                }
            }
    }

    private void islandSpawn()
    {
        // Οι παρακάτω συντεταγμένες (Vector3) είναι με το χέρι!
        Vector3 island_spawn = new Vector3(1.2f, -1.5f, -15f);  // Start of level
        Debug.Log("leveltime = "+ leveltime);
        if (leveltime < 6)
        {
            island_spawn = new Vector3(1.2f, -1.5f, 10f);  // End of level
        }
        Instantiate(islandPrefab, island_spawn, Quaternion.identity);

        
    }
}
