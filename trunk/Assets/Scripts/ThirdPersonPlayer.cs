using UnityEngine;
using System.Collections;

public class ThirdPersonPlayer : MonoBehaviour
{
    public int TeamNo {get; set;}
	
	public int maximumHitPoints = 100;
    public int hitPoints = 100;
	public int damage = 5;
	
	public AudioClip die;
	public AudioClip pain;
	
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
            networkView.RPC("Shoot", RPCMode.All, null);
//			Shoot();
        }
    }
	
    [RPC]
    void Shoot()
    {
        Debug.Log("Fire");
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 100.0f))
        {
            Debug.Log("You shot: " + hit.transform.gameObject.name + " " + TeamNo);
			string teamTag = gameObject.tag;
            if (hit.collider.tag != teamTag)
            {
                hit.collider.SendMessageUpwards("ApplyDamage", hit.transform.position, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
	
    //[RPC]
    //void playDieSound(Vector3 pos)
    //{
    //    AudioSource.PlayClipAtPoint(die, pos);
    //}
	
    [RPC]
    void ApplyDamage(Vector3 pos)
    {
		hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log(hitPoints.ToString());
            AudioSource.PlayClipAtPoint(pain, pos);
        }
    }

	void Die()
	{
		if(networkView.isMine)
		{
			ZombieSpawnManager zm = (ZombieSpawnManager)GameObject.Find("ZombieSpawnManager").GetComponent(typeof(ZombieSpawnManager));
			zm.SpawnZombiePlayer();
			AudioSource.PlayClipAtPoint(die, gameObject.transform.position);
			Network.Destroy(gameObject);
		}
		
	}
}
