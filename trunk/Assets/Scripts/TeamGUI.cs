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
	public Transform playerName1;
	public Transform playerName2;
	public Transform playerName3;
	public Transform playerName4;
	public string nameFromTextField;
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
			nameFromTextField = GUI.TextField(new Rect(55, 10, 100, 20), nameFromTextField, 25);
            string teamNo = "team1";
			setTextMesh1();
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab1, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player1(Clone)"));
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 100, 180, 40), "Team 2"))
        {
            nameFromTextField = GUI.TextField(new Rect(55, 10, 100, 20), nameFromTextField, 25);
            string teamNo = "team2";
			setTextMesh2();
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab2, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player2(Clone)"));
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Team 3"))
        {
			nameFromTextField = GUI.TextField(new Rect(55, 10, 100, 20), nameFromTextField, 25);
            string teamNo = "team3";
			setTextMesh3();
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab3, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player3(Clone)"));
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 200, 180, 40), "Team 4"))
        {
			nameFromTextField = GUI.TextField(new Rect(55, 10, 100, 20), nameFromTextField, 25);
            string teamNo = "team4";
			setTextMesh4();
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab4, new Vector3(25, 2, 60), transform.rotation, 0);
			listOfPlayers.Add(GameObject.Find("Player4(Clone)"));
            DisableMenu();
        }
        GUI.EndGroup();
        
    }

    [RPC]
    void SetPlayerInfo(string teamNo)
    {		
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
	
	void setTextMesh1()
	{
		playerName1.GetComponent<TextMesh>().text = nameFromTextField;
	}
	
	void setTextMesh2()
	{
		playerName2.GetComponent<TextMesh>().text = nameFromTextField;
	}
	
	void setTextMesh3()
	{
		playerName3.GetComponent<TextMesh>().text = nameFromTextField;
	}
	
	void setTextMesh4()
	{
		playerName4.GetComponent<TextMesh>().text = nameFromTextField;
	}
}
