using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public HUDMenuUIController hudMenuController;
    public TextMeshProUGUI livesText;   // text object used to display lives

    private void Start()
    {
        // Set the TMP reference INSIDE the controller
        hudMenuController.SetLivesText(livesText);

        // Show initial lives
        hudMenuController.UpdateLives(lives);
    }

    public void LoseOneLife()
    {
        lives -= 1;
        if (lives < 0) lives = 0;

        Debug.Log("Lives left: " + lives);

        hudMenuController.UpdateLives(lives);

        if (lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        Debug.Log("DEATH");
    }
}
