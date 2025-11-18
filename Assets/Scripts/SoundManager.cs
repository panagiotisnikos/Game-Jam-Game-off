using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource ambience;
    public AudioClip break_sound;
    public AudioClip hit_sound;


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
        ambience.PlayOneShot(hit_sound,0.5f);
    }
        public void BottleBreak()
    {
        ambience.PlayOneShot(break_sound,0.7f);
    }
         public void EndMusic()
    {
        music.Stop();
    }
}
