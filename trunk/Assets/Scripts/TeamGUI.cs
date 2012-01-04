using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TeamGUI : MonoBehaviour 
{

    public Transform playerPrefab1;
	public Transform playerPrefab2;
	public Transform playerPrefab3;
	public Transform playerPrefab4;
	public Transform playerName;
	IList<GameObject> listOfPlayers = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
        this.enabled = true ;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 250));
        GUI.Box(new Rect(0, 0, 300, 250), "Team Menu");

        if (GUI.Button(new Rect(55, 50, 180, 40), "Team 1"))
        {
            string teamNo = "team1";
			string name = "TesterNytNavn1";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo, name);
			Network.Instantiate(playerPrefab1, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player1(Clone)"));
			Network.Instantiate(playerName, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 100, 180, 40), "Team 2"))
        {
            
            string teamNo = "team2";
			string name = "TesterNytNavn2";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo, name);
			Network.Instantiate(playerPrefab2, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player2(Clone)"));
			Network.Instantiate(playerName, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Team 3"))
        {
            string teamNo = "team3";
			string name = "TesterNytNavn3";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo, name);
			Network.Instantiate(playerPrefab3, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player3(Clone)"));
			Network.Instantiate(playerName, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 200, 180, 40), "Team 4"))
        {
            string teamNo = "team4";
			string name = "TesterNytNavn4";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo, name);
			Network.Instantiate(playerPrefab4, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player4(Clone)"));
			Network.Instantiate(playerName, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }
        GUI.EndGroup();
        
    }

    [RPC]
    void SetPlayerInfo(string teamNo, string name)
    {
		TextMesh text = (TextMesh)playerName.gameObject.GetComponent(typeof(TextMesh));
		text.text = name;
		
		if(teamNo.Equals("team1"))
			playerPrefab1.tag = teamNo;
		if(teamNo.Equals("team2"))
			playerPrefab2.tag = teamNo;
		if(teamNo.Equals("team3"))
			playerPrefab3.tag = teamNo;
		if(teamNo.Equals("team4"))
			playerPrefab4.tag = teamNo;
	}


    void DisableMenu()
    {
        this.enabled = false;
    }

    void EnableMenu()
    {
        this.enabled = true;
    }
}
