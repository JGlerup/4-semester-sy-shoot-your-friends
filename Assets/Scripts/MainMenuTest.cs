using UnityEngine;
using System.Collections;

public class MainMenuTest : MonoBehaviour {
    private delegate void GUIMethod();
    private GUIMethod currentGUIMethod;

    void Start()
    {
        // start with the main menu GUI
        this.currentGUIMethod = MainMenu;
    }

    public void MainMenu()
    {
        float areaWidth = 200;
        float areaHeight = 200;
        float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
        GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth,
        areaHeight));

        if (GUILayout.Button("Multiplayer"))
        {
            currentGUIMethod = MultiplayerMenu;
        }
        if (GUILayout.Button("How to Play"))
        {
			currentGUIMethod = HowToPlayMenu;
            //howToPlay.enabled = true;
            //this.enabled = false;
        }
        if (GUILayout.Button("Quit"))
        {
            Application.Quit();
        }

        GUILayout.EndArea();
    }

    private void MultiplayerMenu()
    {
        float areaWidth = 200;
        float areaHeight = 200;
        float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
        GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth,
        areaHeight));

        if (GUILayout.Button("Join Server"))
        {
            this.currentGUIMethod = JoinServerMenu;
        }
        if (GUILayout.Button("Create Server"))
        {
            this.currentGUIMethod = CreateServerMenu;
        }
        if (GUILayout.Button("Exit"))
        {
            this.currentGUIMethod = MainMenu;
        }
        GUILayout.EndArea();
    }

    private void CreateServerMenu()
    {
        float areaWidth = 200;
        float areaHeight = 200;
        float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
        GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth,
        areaHeight));

        if (GUILayout.Button("Create Server"))
        {
            SetupServer setupServer = (SetupServer)GameObject.Find("Server").GetComponent(typeof(SetupServer));
            setupServer.LaunchServer(32, 25000);
        }
        if (GUILayout.Button("Exit"))
        {
            this.currentGUIMethod = MultiplayerMenu;
        }
        GUILayout.EndArea();
    }

    private void JoinServerMenu()
    {
        MasterServer.RequestHostList("ShootYourFriends");
        HostData[] data = MasterServer.PollHostList();
        // Go through all the hosts in the host list
        foreach (HostData element in data)
        {
            GUILayout.BeginHorizontal();
            string name = element.gameName + " " + element.connectedPlayers + " / " + element.playerLimit;
            GUILayout.Label(name);
            GUILayout.Space(5);
            string hostInfo;
            hostInfo = "[";
            foreach (string host in element.ip)
                hostInfo = hostInfo + host + ":" + element.port + " ";
            hostInfo = hostInfo + "]";
            GUILayout.Label(hostInfo);
            GUILayout.Space(5);
            GUILayout.Label(element.comment);
            GUILayout.Space(5);
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Connect"))
            {
                // Connect to HostData struct, internally the correct method is used (GUID when using NAT).
                Application.LoadLevel("City1");
                Network.Connect(element);
            }
            GUILayout.EndHorizontal();
        }
    }
	
	private void HowToPlayMenu()
	{
		float areaWidth = 200;
        float areaHeight = 200;
        float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth,
        areaHeight));
		
		GUILayout.TextArea("U control the player with WASD or the arrow keys and the mouse. U shoot with mouse button 1. Avoid and kill zombies hvile u kill the enemy players on the other teams.");
		if(GUILayout.Button("Back to menu"))
		{
			currentGUIMethod = MainMenu;
		}
	}

    // Update is called once per frame 
    public void OnGUI()
    {
        this.currentGUIMethod();
    } 
}
