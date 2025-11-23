using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject rock_prefab;    //Selects Prefab to spawn
    public GameObject shark_prefab;
    public GameObject seaweed_prefab;
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
        // τυχαία επιλογή 50/50 για το αν θα κάνει
        // spawn ο καρχαρίας δεξιά(1) ή αριστερά(-1)
        int random_side = -13;
        if (Random.value > 0.5f)
        {
            random_side = 13;
        }
            Vector3 spawn_position = new Vector3(random_side, 0, Random.Range(-6, 5));
        Instantiate(shark_prefab, spawn_position, Quaternion.identity);
        soundmanager.SharkSound();  //Plays sound of sharking entering the field
    }

    public void seaweed_spawn()
    {
        Vector3 spawn_position = new Vector3(Random.Range(-8.0f, 8.0f), 0, 12);
        Instantiate(seaweed_prefab, spawn_position, Quaternion.identity);
    }
}
