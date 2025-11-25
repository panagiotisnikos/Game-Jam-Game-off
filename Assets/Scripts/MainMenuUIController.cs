using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{

    public LevelLoaderController lvlLoader;
    public SoundManagerMainMenu soundmanager;
    private float quittimer = 0;
    private bool timer = false;

    public void PlayGame()
    {
        soundmanager.ButtonPressed1();
        lvlLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        soundmanager.ButtonPressed2();
        timer = true;
    }

    public void FixedUpdate()
    {
        if (timer == true)
        {
            quittimer += Time.deltaTime;
            print(quittimer);
        }
        if (quittimer >= 1)
        {
            timer = false;
            quittimer = 0;
            Application.Quit();
        }
    }
}
