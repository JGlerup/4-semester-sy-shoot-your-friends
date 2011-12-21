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
            Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 1);
			ThirdPersonPlayer player = (ThirdPersonPlayer)playerPrefab.gameObject.GetComponent(typeof(ThirdPersonPlayer));
			player.TeamNo = 1;
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 100, 180, 40), "Team 2"))
        {
            Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 2);
			ThirdPersonPlayer player = (ThirdPersonPlayer)playerPrefab.gameObject.GetComponent(typeof(ThirdPersonPlayer));
			player.TeamNo = 2;
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Team 3"))
        {
            Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 2);
			ThirdPersonPlayer player = (ThirdPersonPlayer)playerPrefab.gameObject.GetComponent(typeof(ThirdPersonPlayer));
			player.TeamNo = 3;
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 200, 180, 40), "Team 4"))
        {
            Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 2);
			ThirdPersonPlayer player = (ThirdPersonPlayer)playerPrefab.gameObject.GetComponent(typeof(ThirdPersonPlayer));
			player.TeamNo = 4;
            DisableMenu();
        }
        GUI.EndGroup();
        
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
