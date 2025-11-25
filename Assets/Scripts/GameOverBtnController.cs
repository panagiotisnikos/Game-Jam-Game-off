using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverBtnController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnHoverTxtBtn()
    {
        animator.SetTrigger("OnHover");
    }

    public void OnExitHoverTxtBtn()
    {
        animator.SetTrigger("Normal");
    }
}
