using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject rock_prefab;    //Selects Prefab to spawn
    public GameObject shark_prefab;
    public SoundManager soundmanager;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {

    }

    public void SpawnRock()
    {
        Vector3 spawn_position = new Vector3(Random.Range(-8.0f, 8.0f), 0, 12) ;
        Instantiate(rock_prefab, spawn_position, Quaternion.identity);
    }

    public void shark_spawn()
    {
        Vector3 spawn_position = new Vector3(-10, 0, Random.Range(-10.0f, -3.0f));
        Quaternion rot = new Quaternion();
        rot.Set(0.1882f, 0.6605f, 0.1991f, 0.6989f);
        rot.Set(0, 0, 0.216439605f, 0.976296067f);
        Instantiate(shark_prefab, spawn_position, rot);
        soundmanager.SharkSound();  //Plays sound of sharking entering the field
    }

}
