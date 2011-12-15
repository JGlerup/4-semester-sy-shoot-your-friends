using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
    public GameObject enemy;
    public float spawnTime = 0;
    public float respawnTime = 2.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//        if (Time.time > spawnTime + respawnTime)
//        {
//            Instantiate(enemy, transform.position, transform.rotation);
//            spawnTime = Time.time;
//            respawnTime = 10 * Random.value;
//        }
	}
}
