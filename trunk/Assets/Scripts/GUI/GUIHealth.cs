using UnityEngine;
using System.Collections;
using System;

public class GUIHealth : MonoBehaviour {
    public float health = 100.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
