using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject[] spawnLocationList;
    public List<GameObject> zombieList;
    private float spawnTime = 0;
    private float respawnTime = 2.0f;
    public int minRespawnTime = 2;
    public int maxRespawnTime = 10;
    public int maxNumberOfZombies = 50;
    public int NumberOfZombies { get; set; }

    // Use this for initialization
    private void Start()
    {
        zombieList = new List<GameObject>();
        zombieList.Add(zombie1);
        zombieList.Add(zombie2);
        spawnLocationList = GameObject.FindGameObjectsWithTag("ZombieSpawn");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > spawnTime + respawnTime && NumberOfZombies < 50)
        {
            Transform transform = spawnLocationList[Random.Range(0, spawnLocationList.Length)].transform;
            SpawnZombie(transform.position, transform.rotation);
            spawnTime = Time.time;
            respawnTime = Random.Range(minRespawnTime, maxRespawnTime);
        }
    }

    private void SpawnZombie(Vector3 position, Quaternion rotation)
    {
        Network.Instantiate(zombieList[Random.Range(0, zombieList.Count)], position, rotation, 0);
        NumberOfZombies++;
    }
}
