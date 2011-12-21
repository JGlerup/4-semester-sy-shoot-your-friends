using UnityEngine;
using System.Collections;

public class ThirdPersonPlayer : MonoBehaviour
{
    public AudioClip die;
    public int TeamNo {get; set;}
    // Use this for initialization
    void Start()
    {		
       Debug.Log(TeamNo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
//            networkView.RPC("Shoot", RPCMode.All, transform.position);
			Shoot();
        }
    }
	

    void Shoot()
    {
        Debug.Log("Fire");
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 100.0f))
        {
            Debug.Log("You shot: " + hit.transform.gameObject.name + " " + teamNo);
			ThirdPersonPlayer player = (ThirdPersonPlayer)hit.collider.GetComponent(typeof(ThirdPersonPlayer));
            hit.collider.SendMessageUpwards("ApplyDamage", hit.transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }
	
	[RPC]
	void playDieSound(Vector3 pos)
	{
		AudioSource.PlayClipAtPoint(die, pos);
	}
	

    void ApplyDamage(Vector3 pos)
    {
//        GameObject.Find("Player(Clone)").audio.Play();
 		networkView.RPC("playDieSound", RPCMode.All, pos);
//			AudioSource.PlayClipAtPoint(die, pos);
		
    }
}
