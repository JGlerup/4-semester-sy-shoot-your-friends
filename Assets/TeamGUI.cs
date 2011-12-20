using UnityEngine;
using System.Collections;

public class TeamGUI : MonoBehaviour {

    public Transform playerPrefab;

	// Use this for initialization
	void Start () {
        this.enabled = true ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 250));
        GUI.Box(new Rect(0, 0, 300, 250), "Team Menu");

        if (GUI.Button(new Rect(55, 50, 180, 40), "Team 1"))
        {
            Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 1);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 100, 180, 40), "Team 2"))
        {
            Network.Instantiate(playerPrefab, new Vector3(25, 2, 60), transform.rotation, 2);
            DisableMenu();
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Team 3"))
        {
            Application.Quit();
        }

        if (GUI.Button(new Rect(55, 200, 180, 40), "Exit game"))
        {
            Application.Quit();
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
