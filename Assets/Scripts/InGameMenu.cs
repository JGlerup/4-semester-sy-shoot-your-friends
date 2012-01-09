using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour
{
    private delegate void GUIMethod();
    private GUIMethod currentGUIMethod;
	// Use this for initialization
	void Start ()
	{
		this.currentGUIMethod = GameMenu;
		this.enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void GameMenu()
	{
		float areaWidth = 200;
		float areaHeight = 200;
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		GUILayout.BeginArea (new Rect (ScreenX, ScreenY, areaWidth, areaHeight));
		
		if (GUILayout.Button ("Resume")) 
		{
			Screen.lockCursor = true;
			this.enabled = false;
		}
		if (GUILayout.Button ("Disconnect"))
		{
			Network.Disconnect();
			Application.LoadLevel("MainMenu");
		}
		
		if (GUILayout.Button ("Tutorial"))
		{
			this.currentGUIMethod = HowToPlayMenu;
		}
		
		if (GUILayout.Button ("Quit Game"))
		{
			Application.Quit();
		}
		
		GUILayout.EndArea();
	}
	
	void OnGUI ()
	{
		this.currentGUIMethod();
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
            + "If you die as a zombie, you will respawn as a zombie."
            + "\n";
		
		GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth, areaHeight));
		
        GUILayout.TextArea(text);
        if (GUILayout.Button("Back to menu"))
        {
            this.currentGUIMethod = GameMenu;
        }
        GUILayout.EndArea();
    }
}
