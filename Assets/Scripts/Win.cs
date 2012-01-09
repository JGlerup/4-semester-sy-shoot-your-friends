using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Win : MonoBehaviour 
{
	
	public int winningTeamNumber;
	public List<GameObject> allPlayers = new List<GameObject>();
	public List<GameObject> allZombies = new List<GameObject>();
	private CharacterController cc;
	private MouseLook ml;
	private ThirdPersonPlayer tpp;
	
	
	// Use this for initialization
	void Start () 
	{
		winningTeamNumber = 0;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(winningTeamNumber == 0)
		{
			
		}
		else
		{
			if(winningTeamNumber == 1)
			{
				networkView.RPC("Win1", RPCMode.All, null);
			}
			if(winningTeamNumber == 2)
			{
				//Win2();
			}
			if(winningTeamNumber == 3)
			{
				//Win3();
			}
			if(winningTeamNumber == 4)
			{
				//Win4();
			}
		}
	
	}
	
	[RPC]
	void Win1()
	{
		allPlayers.AddRange(GameObject.FindGameObjectsWithTag("team1"));
		DisablePlayers();
		//Write to all who won
		Wait();
		//goto MainMenu
	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(10);
	}
	
	void DisablePlayers()
	{
		allZombies.AddRange(GameObject.FindGameObjectsWithTag("Player"));
				
		foreach(GameObject g in allZombies)
		{
			g.transform.Rotate(0,180,0);
			g.animation.Play("idle");
			cc = (CharacterController)g.GetComponent(typeof(CharacterController));
			cc.enabled = false;
			ml = (MouseLook)g.GetComponent(typeof(MouseLook));
			ml.enabled = false;
			tpp = (ThirdPersonPlayer)g.GetComponent(typeof(ThirdPersonPlayer));
			tpp.enabled = false;
		}
		
		foreach(GameObject g in allPlayers)
		{
			g.transform.Rotate(0,180,0);
			g.animation.Play("dance");
			cc = (CharacterController)g.GetComponent(typeof(CharacterController));
			cc.enabled = false;
			ml = (MouseLook)g.GetComponent(typeof(MouseLook));
			ml.enabled = false;
			tpp = (ThirdPersonPlayer)g.GetComponent(typeof(ThirdPersonPlayer));
			tpp.enabled = false;
		}
	}
}
