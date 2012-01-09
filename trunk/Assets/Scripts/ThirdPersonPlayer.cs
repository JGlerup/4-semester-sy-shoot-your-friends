using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThirdPersonPlayer : MonoBehaviour
{
    public int TeamNo {get; set;}
	public int check = 0;

    private HUD hud;
	public int maximumHitPoints = 100;
    public int hitPoints = 100;
    //public int damage = 5;
	
	public AudioClip die;
	public AudioClip pain;
	public Transform smoke;
	
	IList<GameObject> team1List = new List<GameObject>();
	IList<GameObject> team2List = new List<GameObject>();
	IList<GameObject> team3List = new List<GameObject>();
	IList<GameObject> team4List = new List<GameObject>();
	
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
        //if (Input.GetButton ("Fire1")) 
        //{
        //    networkView.RPC ("Shoot", RPCMode.All, null);
        //}
		
		if (inGameMenu.enabled) 
		{	
			ml.enabled = false;
		}
		ml.enabled = true;
	}
	
    //[RPC]
    //void Shoot()
    //{
    //    Debug.Log("Fire");
    //    Vector3 direction = transform.TransformDirection(Vector3.forward);
    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, direction, out hit, 100.0f))
    //    {
    //        Debug.Log("You shot: " + hit.transform.gameObject.name + " " + TeamNo);
    //        string teamTag = gameObject.tag;
    //        if (hit.collider.tag != teamTag)
    //        {
    //            hit.collider.SendMessageUpwards("ApplyDamage", hit.transform.position, SendMessageOptions.DontRequireReceiver);
    //        }
    //    }
    //}
	
    //[RPC]
    //void playDieSound(Vector3 pos)
    //{
    //    AudioSource.PlayClipAtPoint(die, pos);
    //}

    [RPC]
    void ApplyDamage(int damage)
    {

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            check += 1;
            if (check == 1)
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
            AudioSource.PlayClipAtPoint(pain, transform.position);
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
			CheckTeams();
		}//end if
		
	}
	
	[RPC]
	void CheckTeams()
	{
		team1List = GameObject.FindGameObjectsWithTag("team1");
		team2List = GameObject.FindGameObjectsWithTag("team2");
		team3List = GameObject.FindGameObjectsWithTag("team3");
		team4List = GameObject.FindGameObjectsWithTag("team4");
		
		if(team1List.Count == 0 && team2List.Count == 0 && team3List.Count == 0)
		{
			Win guiWin = (Win)GameObject.Find("GUI").GetComponent(typeof(Win));
			guiWin.winningTeamNumber = 4;
		}
		
		if(team2List.Count == 0 && team3List.Count == 0 && team4List.Count == 0)
		{
			Win guiWin = (Win)GameObject.Find("GUI").GetComponent(typeof(Win));
			guiWin.winningTeamNumber = 1;
		}
		
		if(team1List.Count == 0 && team3List.Count == 0 && team4List.Count == 0)
		{
			Win guiWin = (Win)GameObject.Find("GUI").GetComponent(typeof(Win));
			guiWin.winningTeamNumber = 2;
		}
		
		if(team1List.Count == 0 && team2List.Count == 0 && team4List.Count == 0)
		{
			Win guiWin = (Win)GameObject.Find("GUI").GetComponent(typeof(Win));
			guiWin.winningTeamNumber = 3;
		}
		
	}
}
