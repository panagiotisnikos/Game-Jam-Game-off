using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoaderController : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;


    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelRoutine(levelName));
    }

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelRoutine(levelIndex));
    }

    // stalls the load so the animation can play 
    // Coroutine
    public IEnumerator LoadLevelRoutine(int levelIndex)
    {
        // Debug.Log("LoadLevel INT called: " + levelIndex);
        // Play aniamtion
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSecondsRealtime(transitionTime + 1);


        // Reset time for next scene
        Time.timeScale = transitionTime;

        //Load scene
        SceneManager.LoadSceneAsync(levelIndex);
    }

    public IEnumerator LoadLevelRoutine(string levelName)
    {
        // Debug.Log("LoadLevel STRING called: " + levelName);
        // Play aniamtion
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSecondsRealtime(transitionTime + 1);


        // Reset time for next scene
        Time.timeScale = transitionTime;

        //Load scene
        SceneManager.LoadSceneAsync(levelName);
    }

}
