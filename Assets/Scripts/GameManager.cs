using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Fields presented in the Inspector
    public static int maxLives = 6;
    public int currentLives = maxLives;
    public HUDMenuUIController hudMenuController; // handles functionality in the UI
    public TextMeshProUGUI livesText;   // text object used to display lives
    public Transform heartsContainer;
    public GameObject livesIcon; // heartIcon prefab
    public Sprite heartFull; // presentation of a full heart
    public Sprite heartEmpty; // presentation of an empty heart

    private void Start()
    {
        // Initialize dependencies with HUD Menu Controller
        // we use methods for encapsulation - we don't directly open the field => fileds private
        // we access them through methods
        hudMenuController.SetLivesText(livesText);
        hudMenuController.SetHeartsContainer(heartsContainer);
        hudMenuController.SetHeartIcon(livesIcon);
        hudMenuController.SetHeartSprites(heartFull, heartEmpty);

        // Build and show initial lives
        hudMenuController.BuildHearts(maxLives);
        hudMenuController.UpdateLives(currentLives, maxLives);
    }

    public void LoseOneLife()
    {
        currentLives -= 1;
        if (currentLives < 0) currentLives = 0;

        Debug.Log("Lives left: " + currentLives + "/" + maxLives);

        hudMenuController.UpdateLives(currentLives, maxLives);

        if (maxLives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        Debug.Log("DEATH");
    }
}
