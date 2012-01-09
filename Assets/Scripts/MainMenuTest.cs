using UnityEngine;
using System.Collections;

public class MainMenuTest : MonoBehaviour
{
	public string serverName = "";
	public string serverDescription = "";
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
		
		GUILayout.Label("Server Name");
		serverName = GUILayout.TextField(serverName, 25);
		GUILayout.Label("Server Description");
		serverDescription = GUILayout.TextField(serverDescription, 40);
        if (GUILayout.Button("Create Server"))
        {
            SetupServer setupServer = (SetupServer)GameObject.Find("Server").GetComponent(typeof(SetupServer));
            setupServer.LaunchServer(32, 25000, serverName, serverDescription);
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
        float areaWidth = 400;
        float areaHeight = 400;
        float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));

        string text = "------Controls------ \n"
            + "Movement: WASD or arrow keys and mouse \n"
            + "Shooting: Mouse button 1 (left-mouse button) \n"
            + "Jumping: Space \n"
            + "Running: Hold shift while moving \n"
            + "In-game menu: Escape \n"
            + "\n"
            + "--------Server-------- \n"
            + "Join: Multiplayer->Join server-> Connect to a server from the list->Name your player->Choose team \n"
            + "Create: Multiplayer->Create Server->Create Server->Name your player-> Choose team \n"
            + "\n"
            + "--------Goal-------- \n"
            + "When you join a team, you spawn in a house as a skeleton. All skeletons have a name above their heads. Each team looks alike. There is no friendly fire. \n"
            + "Defeat all other teams, and avoid getting killed by zombies (Spartan king and construction worker) to win. \n"
            + "The winning team will perform a dance \n"
			+ "When you die, you become a zombie and you can attack all teams but not zombies. \n"
            + "If you die as a zombie, you’ will respawn as a zombie."
            + "\n";

        GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth,
        areaHeight));

        GUILayout.TextArea(text);
        if (GUILayout.Button("Back to menu"))
        {
            currentGUIMethod = MainMenu;
        }
        GUILayout.EndArea();
    }

    // Update is called once per frame 
    public void OnGUI()
    {
        this.currentGUIMethod();
    }
}
