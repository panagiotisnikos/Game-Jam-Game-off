using UnityEngine;

public class GameOverControllerWin : MonoBehaviour
{

    public LevelLoaderController lvlLoader;
    private float quittimer = 0;
    private bool timer = false;
    public SoundManager soundmanager;

    public void RetryGame()
    {
        soundmanager.ButtonPressed1();
        lvlLoader.LoadLevel(1);
    }

    public void QuitGame()
    {
        soundmanager.ButtonPressed2();
        timer = true;
    }

    public void MainMenu()
    {
        soundmanager.ButtonPressed1();
        lvlLoader.LoadLevel(0);
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
