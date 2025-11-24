using UnityEngine;

public class SoundManagerMainMenu : MonoBehaviour
{
    public AudioSource main_menu;
    public AudioClip Button1;
    public AudioClip Button2;

    void Start()
    {
        main_menu.Play();
    }

 public void ButtonPressed1()
    {
        main_menu.PlayOneShot(Button1);
    }

 public void ButtonPressed2()
    {
        main_menu.PlayOneShot(Button2);
    }
}
