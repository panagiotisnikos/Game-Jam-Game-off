using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject rock_prefab;    //Selects Prefab to spawn
  

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

}
