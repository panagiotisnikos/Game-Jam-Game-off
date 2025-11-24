using UnityEngine;

public class VictoryUI : MonoBehaviour
{
public GameObject notificationPanel;
public GameObject readLetterPanel;
public void OpenLetter()
    {
        notificationPanel.SetActive(false); // Κρύβει το αρχικό μήνυμα
        readLetterPanel.SetActive(true);    // Εμφανίζει το γράμμα
    }

//Άμα θέλουμε να βάλουμε back, μπορούμε να χρησιμοποιήσουμε την παρακάτω method
public void CloseLetter()
    {
        readLetterPanel.SetActive(false);
        notificationPanel.SetActive(true);
    }
}
