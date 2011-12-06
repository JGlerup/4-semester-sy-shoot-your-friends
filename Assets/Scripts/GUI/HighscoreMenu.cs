using UnityEngine;
using System.Collections;

public class HighscoreMenu : MonoBehaviour
{
	private float startTime;

    // Use this for initialization
    void Start()
    {
		startTime = Time.time;
        this.enabled = false;
    }

    public void OnGUI()
    {
        DrawHighscoreMenu();
    }

    public void DrawHighscoreMenu()
    {
        GameObject go = GameObject.Find("GUI");
        HUD hud = (HUD)go.GetComponent(typeof(HUD));
        hud.enabled = false;
        Screen.lockCursor = false;
        int guiTime = (int)(Time.time - startTime);
        int minutes = guiTime / 60;
        int seconds = guiTime % 60;
        string textTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 120, 300, 250));
        GUI.Box(new Rect(0, 0, 300, 250), "Highscore");
        GUI.Label(new Rect(55, 50, 180, 40), "Your time: " + textTime);
        if (GUI.Button(new Rect(55, 100, 180, 40), "Restart"))
        {
            Application.LoadLevel(Application.loadedLevel);
            Time.timeScale = 1.0f;
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Exit to Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }

        if (GUI.Button(new Rect(55, 200, 180, 40), "Exit Game"))
        {
            Application.Quit();
        }
        GUI.EndGroup();
    }
}
