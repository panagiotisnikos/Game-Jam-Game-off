using UnityEngine;
using UnityEngine.SceneManagement; // Χρειάζεται για να καλέσεις το SceneManager και να αλλάξεις σκηνή...

public class VictoryUI : MonoBehaviour
{
    public GameObject notificationPanel;
    public GameObject readLetterPanel;
    public GameObject backgroundOverlay;
    public GameObject victoryPanel;
    public SoundManager soundmanager;
    public LevelLoaderController lvlLoader;

    public void OpenLetter()
    {
        notificationPanel.SetActive(false); // Κρύβει το αρχικό μήνυμα
        readLetterPanel.SetActive(true);    // Εμφανίζει το γράμμα
        soundmanager.LetterSound();
        soundmanager.LetterMusic();
    }

    //Άμα θέλουμε να βάλουμε back, μπορούμε να χρησιμοποιήσουμε την παρακάτω method
    public void CloseLetter()
    {
        readLetterPanel.SetActive(false);
        notificationPanel.SetActive(false);
        backgroundOverlay.SetActive(false);
        // -2: scenes - mainMenu - gameOver
        int numberOfScenes = SceneManager.sceneCountInBuildSettings - 2;
        if (numberOfScenes == SceneManager.GetActiveScene().buildIndex)
        {
            victoryPanel.SetActive(true);
        }
        else
        {
            lvlLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
}
