using UnityEngine;

public class GameOverController : MonoBehaviour
{

    public LevelLoaderController lvlLoader;
    private float quittimer = 0;
    private bool timer = false;

    public void RetryGame()
    {
        lvlLoader.LoadLevel(1);
    }

    public void QuitGame()
    {
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
