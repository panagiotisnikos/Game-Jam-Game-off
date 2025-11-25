using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDMenuUIController : MonoBehaviour
{
    public TextMeshProUGUI lvlStart_text;
    public TextMeshProUGUI lvlEnd_text;
    public Transform heartsContainer; // required to know where we will append the hearts
    public GameObject heartIcon; // the element we want to append on the screen dynamiucally
    public RectTransform navigation;
    public RectTransform startIsland;
    public RectTransform endIsland;
    private Vector2 navStart;
    private Vector2 navEnd;
    private List<HeartIconController> livesState = new List<HeartIconController>();

    public void Start()
    {
        navStart.x = startIsland.anchoredPosition.x;
        navStart.y = navigation.anchoredPosition.y;
        navEnd.x = endIsland.anchoredPosition.x;
        navEnd.y = navigation.anchoredPosition.y;
        navigation.anchoredPosition = navStart;

    }

    // ---------------------------- SETTERS ---------------------------------------
    // for the private fieds, so we can access them from other classes
    public void SetLvlStartText(string text)
    {
        Debug.Log(text);
        lvlStart_text.text = text;
    }
    public void SetLvlEndText(string text)
    {
        lvlEnd_text.text = text;
    }

    public void SetHeartsContainer(Transform container)
    {
        heartsContainer = container;
    }

    public void SetHeartIcon(GameObject heartIconPrefab)
    {
        heartIcon = heartIconPrefab;
    }

    // ----------------------- GETTERS -------------------------------



    //--------------------- BUILDING / UPDATES HEARTS -----------------------------------

    // Method used to update the lives in the UI - presentation lvl
    public void UpdateLives(int currentLives, int maxLives)
    {
        // if (livesText != null)
        // {
        //     livesText.text = $"Lives: {currentLives}/{maxLives}";
        // }
        // else
        // {
        //     Debug.LogWarning("HUDMenuUIController: livesText is NOT assigned!");
        // }
        if (heartsContainer != null && livesState.Count != 0)
        {
            for (int life = 0; life < livesState.Count; life++)
            {
                if (life < currentLives)
                {
                    livesState[life].SetFull();
                }
                else
                {
                    livesState[life].SetEmpty();
                }
            }
        }
        else
        {
            Debug.LogWarning("HUDMenuUIController: heartsContainer or livesState is NOT assigned!");
        }
    }

    // Method used to build the hearts in the UI dynamically. 
    // why ? -> because we want if we set a different number to the game manager: maxLives = 6
    // to have the same number of icons presented 
    // used only once, then we just update the values ! Destroying and Rebuilding stuff directly
    // on the hierarchy tree is not a good practice - it's expensive ! so we do this only once ! adding elements dynamically only once !
    public void BuildHearts(int maxLives)
    {
        if (heartsContainer != null && heartIcon != null)
        {
            // 1. Clear old heart icons from the scene
            foreach (Transform child in heartsContainer)
            {
                Destroy(child.gameObject);
            }

            // 2. Clear old references from the list
            livesState.Clear();

            // create 1 heart per life
            for (int life = 0; life < maxLives; life++)
            {
                // create a game object inside the heartsContainer
                // we don't need to set the image - the prefab already knows the image
                GameObject heartGO = Object.Instantiate(heartIcon, heartsContainer);
                // why ? -> we need to update our code state of lives
                HeartIconController heart = heartGO.GetComponent<HeartIconController>();
                if (heart != null)
                {
                    // add it to the list
                    livesState.Add(heart);
                }
                else
                {
                    Debug.LogWarning("Heart prefab has no Image component!");
                }
            }
        }
        else
        {
            Debug.LogWarning("HUDMenuController: heartsContainer or heartIcon NOT ready");
        }
    }

    public void PlayLoseLifeEffect(int lostHeartIndex)
    {
        if (lostHeartIndex < 0 || lostHeartIndex >= livesState.Count)
        {
            return;
        }
        livesState[lostHeartIndex].PlayHit();
    }


    // ------------------------ NAVIGATION ---------------------------------------
    public void NavigationMovement(float normalizedPosition)
    {
        // Debug.Log(normalizedPosition);
        normalizedPosition = Mathf.Clamp01(normalizedPosition);
        navigation.anchoredPosition = Vector2.Lerp(navStart, navEnd, normalizedPosition);
    }
}
