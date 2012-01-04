using UnityEngine;
using System.Collections;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject zombie;
    public GameObject[] spawnLocationList;
    private float spawnTime = 0;
    private float respawnTime = 2.0f;
    public int minRespawnTime = 2;
    public int maxRespawnTime = 10;

    // Use this for initialization
    void Start()
    {
        spawnLocationList = GameObject.FindGameObjectsWithTag("ZombieSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + respawnTime)
        {
            Transform transform = spawnLocationList[Random.Range(0, spawnLocationList.Length)].transform;
            SpawnZombie(transform.position, transform.rotation);
            spawnTime = Time.time;
            respawnTime = Random.Range(minRespawnTime, maxRespawnTime);
        }
    }

    void SpawnZombie(Vector3 position, Quaternion rotation)
    {
        Instantiate(zombie, transform.position, transform.rotation);
    }
}
