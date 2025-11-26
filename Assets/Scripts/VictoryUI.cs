using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    public GameObject notificationPanel;
    public GameObject readLetterPanel;
    public GameObject backgroundOverlay;
    public SoundManager soundmanager;

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
    }
}
