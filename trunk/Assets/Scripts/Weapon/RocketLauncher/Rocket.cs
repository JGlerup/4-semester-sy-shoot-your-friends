using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
    public GameObject explosion;
    public float timeOut;
    //public AudioClip lyden;
	// Use this for initialization
	void Start () {
        timeOut = 3.0f;
        Invoke("Kill", timeOut);
	}

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0]; //Fortæller hvor explosionen fandt sted i 3d space (contact indeholder punktet)
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal); //"translaterer" eksplosionens y-akse i forhold til local space (mur = udad osv.)
        Instantiate(explosion, contact.point, rotation);
        //audio.PlayOneShot(lyden);
        //audio.Play();
        Kill();
        Debug.Log("Rocket destroyed");
        
    }

    void Kill()
    {
        ParticleEmitter emitter = (ParticleEmitter)GetComponentInChildren(typeof(ParticleEmitter));
        if (emitter)
            emitter.emit = false;

        transform.DetachChildren();

        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
