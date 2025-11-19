using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource ambience;
    public AudioClip break_sound;
    public AudioClip hit_sound;
    public AudioClip rockhit_sound;
    public AudioClip shark_sound;
    public AudioClip sharkhit_sound;


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
        ambience.PlayOneShot(sharkhit_sound,1.5f);
    }

    public void SharkSound()
    {
        ambience.PlayOneShot(shark_sound,0.5f);
    }
}
