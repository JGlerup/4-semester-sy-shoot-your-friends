using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject zombie1;
    public GameObject zombie2;
	public GameObject zombiePlayer1;
	public GameObject zombiePlayer2;
    public GameObject[] spawnLocationList;
    public List<GameObject> zombieList;
	public List<GameObject> zombiePlayerList;
    private float spawnTime = 0;
    private float respawnTime = 2.0f;
    public int minRespawnTime = 2;
    public int maxRespawnTime = 4;
    public int maxNumberOfZombies = 50;
//    public int NumberOfZombies { get; set; }
	
	public int numberOfZombies = 0;
	
	public int NumberOfZombies
	{
		get { return numberOfZombies; }
		set { numberOfZombies = value; }
	}

    // Use this for initialization
    private void Start()
    {
        zombieList = new List<GameObject>();
        zombieList.Add(zombie1);
        zombieList.Add(zombie2);
        spawnLocationList = GameObject.FindGameObjectsWithTag("ZombieSpawn");
		zombiePlayerList = new List<GameObject>();
		zombiePlayerList.Add(zombiePlayer1);
        zombiePlayerList.Add(zombiePlayer2);
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
	
	public void SpawnZombiePlayer()
	{
		Transform transform = spawnLocationList[Random.Range(0, spawnLocationList.Length)].transform;
		Network.Instantiate(zombiePlayerList[Random.Range(0, zombiePlayerList.Count)], new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation, 0);
	}
}
