using UnityEngine;

public class GameOverController : MonoBehaviour
{

    public LevelLoaderController lvlLoader;
    public SoundManagerMainMenu soundmanager;
    private float quittimer = 0;
    private bool timer = false;

    public void RetryGame()
    {
        soundmanager.ButtonPressed1();
        // start the function - but because coroutine, we initialize with StartCoroutine() function
        StartCoroutine(lvlLoader.LoadLevel(1));
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
