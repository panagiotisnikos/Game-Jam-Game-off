using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource music2;
    public AudioSource ambience;
    public AudioClip break_sound;
    public AudioClip hit_sound;
    public AudioClip rockhit_sound;
    public AudioClip shark_sound;
    public AudioClip sharkhit_sound;
    public AudioClip letter_sound;
    public AudioClip win_sound;
    public GameObject seaweed_audiosource_prefab;

    public AudioClip Button1;
    
    public AudioClip Button2;

    private bool inside_seaweed = false;
    private GameObject temp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
        ambience.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BottleHit()
    {
        ambience.PlayOneShot(hit_sound,0.3f);
    }
        public void BottleBreak()
    {
        ambience.PlayOneShot(break_sound,0.7f);
    }
         public void EndMusic()
    {
        music.Stop();
    }

     public void HitRock()
    {
        ambience.PlayOneShot(rockhit_sound,0.7f);
    }
       public void HitShark()
    {
        ambience.PlayOneShot(sharkhit_sound,1.2f);
    }

    public void SharkSound()
    {
        ambience.PlayOneShot(shark_sound,0.8f);
    }

        public void SeaweedSoundOn()
    {
        if (inside_seaweed == false)
        {
            temp = Instantiate(seaweed_audiosource_prefab);
            inside_seaweed = true;
        }
    }

            public void SeaweedSoundOff()
    {
        if (inside_seaweed == true)
        {
           Destroy(temp);  
           inside_seaweed = false;
        }
    }

    public void WinSound()
    {
        ambience.PlayOneShot(win_sound,0.6f);
    }
        public void LetterSound()
    {
        SeaweedSoundOff();
        ambience.PlayOneShot(letter_sound,0.7f);
    }
        public void LetterMusic()
    {
        music2.Play();
    }


     public void ButtonPressed1()
    {
        ambience.PlayOneShot(Button1,0.7f);
    }

     public void ButtonPressed2()
    {
        ambience.PlayOneShot(Button2,0.7f);
    }
}
