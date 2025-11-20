using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{

    public LevelLoaderController lvlLoader;
    public void PlayGame()
    {
        // start the function - but because coroutine, we initialize with StartCoroutine() function
        StartCoroutine(lvlLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
