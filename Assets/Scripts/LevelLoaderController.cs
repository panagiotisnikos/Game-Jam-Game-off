using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoaderController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // stalls the load so the animation can play 
    // Coroutine
    public IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("LoadLevel INT called: " + levelIndex);
        // Play aniamtion
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadSceneAsync(levelIndex);
    }

    public IEnumerator LoadLevel(string levelName)
    {
        Debug.Log("LoadLevel STRING called: " + levelName);
        // Play aniamtion
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadSceneAsync(levelName);
    }

}
