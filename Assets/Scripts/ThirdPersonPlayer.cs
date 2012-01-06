using UnityEngine;
using System.Collections;

public class ThirdPersonPlayer : MonoBehaviour
{
    public int TeamNo {get; set;}
	public int check = 0;

    private HUD hud;
	public int maximumHitPoints = 100;
    public int hitPoints = 100;
	public int damage = 5;
	
	public AudioClip die;
	public AudioClip pain;
	public Transform smoke;
	
    // Use this for initialization
    void Start()
    {		
    	Debug.Log(TeamNo);
        GameObject go = GameObject.Find("GUI");
        hud = (HUD)go.GetComponent(typeof(HUD));
        if (networkView.isMine)
        {
            hud.enabled = true;
            hud.UpdateGUIHealth(hitPoints);
        }
    }

    // Update is called once per frame
	void Update ()
	{
		GameObject go = GameObject.Find ("GUI");
		MouseLook ml = GetComponent<MouseLook> ();
		InGameMenu inGameMenu = (InGameMenu)go.GetComponent (typeof(InGameMenu));
		if (Input.GetKey (KeyCode.Escape)) 
		{
			inGameMenu.enabled = true;
			Screen.lockCursor = false;
		}
		if (Input.GetButton ("Fire1")) 
		{
			networkView.RPC ("Shoot", RPCMode.All, null);
		}
		
		if (inGameMenu.enabled) 
		{	
			ml.enabled = false;
		}
		ml.enabled = true;
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
			check += 1;
			if(check == 1)
			{
                if (networkView.isMine)
                {
                    hud.UpdateGUIHealth(0);
                }
				Die();
			}//end if
            
        }//end if
        else
        {
            Debug.Log(hitPoints.ToString());
            AudioSource.PlayClipAtPoint(pain, pos);
            if (networkView.isMine)
            {
                hud.UpdateGUIHealth(hitPoints);
            }
        }//end else
    }

	void Die()
	{
		if(networkView.isMine)
		{
			ZombieSpawnManager zm = (ZombieSpawnManager)GameObject.Find("ZombieSpawnManager").GetComponent(typeof(ZombieSpawnManager));
			zm.SpawnZombiePlayer();
			AudioSource.PlayClipAtPoint(die, gameObject.transform.position);
			Network.Instantiate(smoke, transform.position, transform.rotation, 0);
			Network.Destroy(gameObject);
		}//end if
		
	}
}
