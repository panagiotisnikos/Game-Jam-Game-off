using UnityEngine;
using UnityEngine.UI;

public class HeartIconController : MonoBehaviour
{

    private Animator animator;
    private Image state;
    public Sprite heartFull; // presentation of heart when the life is full
    public Sprite heartEmpty; // presentation when life is lost
    public Sprite heartHit; // presentation of heart when hit

    public void SetFull()
    {
        if (state != null && heartFull != null)
        {
            state.sprite = heartFull;
        }
        else
        {
            Debug.LogWarning("HeartIconController: state or heartFull is NOT assigned!");
        }
    }

    public void SetEmpty()
    {
        if (state != null && heartEmpty != null)
        {
            state.sprite = heartEmpty;
        }
        else
        {
            Debug.LogWarning("HeartIconController: state or heartEmpty is NOT assigned!");
        }
    }

    public void SetHit()
    {
        if (state != null && heartHit != null)
        {
            state.sprite = heartHit;
        }
        else
        {
            Debug.LogWarning("HeartIconController: state or heartHit is NOT assigned!");
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<Image>();
    }
    public void PlayHit()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
    }

}
