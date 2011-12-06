using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;
        Screen.lockCursor = true;
        this.enabled = false;
    }

    private void DrawPauseMenu()
    {
        stateComponenets(false);
		Screen.lockCursor = false;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 120, 300, 250));
        GUI.Box(new Rect(0, 0, 300, 250), "Pause Menu");
        if (GUI.Button(new Rect(55, 50, 180, 40), "Resume"))
        {
            ResumeGame();
        }

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

    public void ResumeGame()
    {
        stateComponenets(true);
        Screen.lockCursor = true;
        this.enabled = false;
    }

    private void OnGUI()
    {
        Screen.showCursor = true;
        DrawPauseMenu();
    }

    public void stateComponenets(bool enable)
    {
        HUD hud = (HUD)GetComponent(typeof(HUD));
        Crosshair ch = (Crosshair)GetComponent(typeof(Crosshair));
        GameObject goFps = GameObject.Find("First Person Controller");
        MouseLook mlx = (MouseLook)goFps.GetComponent(typeof(MouseLook));
        GameObject goMc = GameObject.Find("Main Camera");
        MouseLook mly = (MouseLook)goMc.GetComponent(typeof(MouseLook));
        GameObject goW = GameObject.Find("Weapons");
        PlayersWeapons pw = (PlayersWeapons)goW.GetComponent(typeof(PlayersWeapons));

        if (!enable)
        {
            hud.enabled = false;
            ch.enabled = false;
            Time.timeScale = 0.0f;
            mlx.enabled = false;
            mly.enabled = false;
            pw.enabled = false;
        }
        else
        {
            Time.timeScale = 1.0f;
            hud.enabled = true;
            ch.enabled = true;
            mlx.enabled = true;
            mly.enabled = true;
            pw.enabled = true;
        }
    }
}