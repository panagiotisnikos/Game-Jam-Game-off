using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDMenuUIController : MonoBehaviour
{
    private TextMeshProUGUI livesText;   // stays fully private
    private Transform heartsContainer; // required to know where we will append the hearts
    private GameObject heartIcon; // the element we want to append on the screen dynamiucally
    private Sprite heartFull; // presentation of heart when the life is full
    private Sprite heartEmpty; // presentation when life is lost
    private List<Image> livesState = new List<Image>();

    // ---------------------------- SETTERS ---------------------------------------
    // for the private fieds, so we can access them from other classes
    public void SetLivesText(TextMeshProUGUI text)
    {
        livesText = text;
    }

    public void SetHeartsContainer(Transform container)
    {
        heartsContainer = container;
    }

    public void SetHeartSprites(Sprite heartFullIcon, Sprite heartEmptyIcon)
    {
        heartFull = heartFullIcon;
        heartEmpty = heartEmptyIcon;
    }

    public void SetHeartIcon(GameObject heartIconPrefab)
    {
        heartIcon = heartIconPrefab;
    }


    //--------------------- BUILDING / UPDATES HEARTS -----------------------------------

    // Method used to update the lives in the UI - presentation lvl
    public void UpdateLives(int currentLives, int maxLives)
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {currentLives}/{maxLives}";
        }
        else
        {
            Debug.LogWarning("HUDMenuUIController: livesText is NOT assigned!");
        }
        if (heartsContainer != null && livesState.Count != 0)
        {
            for (int life = 0; life < livesState.Count; life++)
            {
                livesState[life].sprite = life < currentLives ? heartFull : heartEmpty;
            }
        }
        else
        {
            Debug.LogWarning("HUDMenuUIController: livesText is NOT assigned!");
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
                // get the image from the obj
                // why ? -> we need to update our code state of lives
                Image sprite = heartGO.GetComponent<Image>();
                if (sprite != null)
                {
                    // add it to the list
                    livesState.Add(sprite);
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
}
