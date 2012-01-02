using UnityEngine;
using System.Collections;

public class TeamGUI : MonoBehaviour {

    public Transform playerPrefab;

	// Use this for initialization
	void Start () {
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
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 100, 180, 40), "Team 2"))
        {
            
            string teamNo = "team2";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Team 3"))
        {
            string teamNo = "team3";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 200, 180, 40), "Team 4"))
        {
            string teamNo = "team4";
            networkView.RPC("SetPlayerInfo", RPCMode.AllBuffered, teamNo);
			Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 0);
            DisableMenu();
        }
        GUI.EndGroup();
        
    }

    [RPC]
    void SetPlayerInfo(string teamNo)
    {
		playerPrefab.tag = teamNo;
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
