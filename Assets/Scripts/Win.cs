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
				networkView.RPC("Win2", RPCMode.All, null);
			}
			if(winningTeamNumber == 3)
			{
				networkView.RPC("Win3", RPCMode.All, null);
			}
			if(winningTeamNumber == 4)
			{
				networkView.RPC("Win4", RPCMode.All, null);
			}
		}
	
	}
	
	[RPC]
	void Win1()
	{
		allPlayers.AddRange(GameObject.FindGameObjectsWithTag("team1"));
		DisablePlayers();
		WriteAll("Team 1");
		StartCoroutine(Wait(5.0f,"City1"));
		//Screen.lockCursor = false;
		//Application.LoadLevel("City1");
	}
	[RPC]
	void Win2()
	{
		allPlayers.AddRange(GameObject.FindGameObjectsWithTag("team2"));
		DisablePlayers();
		WriteAll("Team 2");
		StartCoroutine(Wait(5.0f,"City1"));
		//Screen.lockCursor = false;
		//Application.LoadLevel("City1");
	}
	[RPC]
	void Win3()
	{
		allPlayers.AddRange(GameObject.FindGameObjectsWithTag("team3"));
		DisablePlayers();
		WriteAll("Team 3");
		StartCoroutine(Wait(5.0f,"City1"));
		//Screen.lockCursor = false;
		//Application.LoadLevel("City1");
	}
	[RPC]
	void Win4()
	{
		allPlayers.AddRange(GameObject.FindGameObjectsWithTag("team4"));
		DisablePlayers();
		WriteAll("Team 4");
		StartCoroutine(Wait(5.0f,"City1"));
		//Screen.lockCursor = false;
		//Application.LoadLevel("City1");
	}
	
	
	
	void WriteAll(string text)
	{
		VictoryText vt = (VictoryText)GameObject.Find("GUI").GetComponent(typeof(VictoryText));
			vt.enabled = true;
			vt.WinningTeam = text;
			
	}
	
	IEnumerator Wait(float delay, string level)
	{
		yield return new WaitForSeconds(delay);
		Screen.lockCursor = false;
		Application.LoadLevel(level);
	}
	
	void DisablePlayers()
	{
		allZombies.AddRange(GameObject.FindGameObjectsWithTag("Player"));
				
		foreach(GameObject g in allZombies)
		{			
			cc = (CharacterController)g.GetComponent(typeof(CharacterController));
			cc.enabled = false;
//			tpp = (ThirdPersonPlayer)g.GetComponent(typeof(ThirdPersonPlayer));
//			tpp.enabled = false;
			g.transform.Rotate(0,180,0);
			g.animation.Play("idle");
		}
		
		foreach(GameObject g in allPlayers)
		{
			
			cc = (CharacterController)g.GetComponent(typeof(CharacterController));
			cc.enabled = false;
			ml = (MouseLook)g.GetComponent(typeof(MouseLook));
			ml.enabled = false;
			tpp = (ThirdPersonPlayer)g.GetComponent(typeof(ThirdPersonPlayer));
			tpp.enabled = false;
			g.transform.Rotate(0,180,0);
			g.animation.Play("dance");
		}
	}
}
