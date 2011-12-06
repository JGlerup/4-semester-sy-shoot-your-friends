using UnityEngine;
using System.Collections;

//Pistolen er det eneste våben som har uendeligt ammunition. Derfor er der ikke en instansvariabel der holder styr på hvor meget ammo der er.
public class Pistol : MonoBehaviour {
    private float damage;
    private float fireRate;
    private float range;
    private float lastShot;

	// Use this for initialization
	void Start () {
        damage = 10.0f;
        fireRate = 1.0f;
        lastShot = -10.0f;
        range = 10.0f;
	}
	
	// Update is called once per frame
	void Fire () {
        if (Time.time > lastShot + fireRate)
        {
            audio.Play();
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, range))
            {
                SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                lastShot = Time.time - Time.deltaTime;
            }
        }
	}
}
