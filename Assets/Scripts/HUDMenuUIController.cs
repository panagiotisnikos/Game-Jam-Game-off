using UnityEngine;
using TMPro;

public class HUDMenuUIController : MonoBehaviour
{
    private TextMeshProUGUI livesText;   // stays fully private

    // GameManager (or whoever) will call this ONCE at initialization
    public void SetLivesText(TextMeshProUGUI text)
    {
        livesText = text;
    }

    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {lives}";
        }
        else
        {
            Debug.LogWarning("HUDMenuUIController: livesText is NOT assigned!");
        }
    }
}
