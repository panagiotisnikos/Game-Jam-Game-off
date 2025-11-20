using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuBtnController : MonoBehaviour
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
