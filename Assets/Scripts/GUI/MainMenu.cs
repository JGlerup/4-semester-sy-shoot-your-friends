using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        //GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 250));
        GUI.Box(new Rect(0, 0, 300, 250), "Main Menu");

        if (GUI.Button(new Rect(55, 50, 180, 40), "Play"))
        {
            OpenLevel("Island of Terror");
        }

        if (GUI.Button(new Rect(55, 100, 180, 40), "How To Play"))
        {
            OpenLevel("HowToPlay");
        }

        if (GUI.Button(new Rect(55, 150, 180, 40), "Exit Game"))
        {
            Application.Quit();
        }

        GUI.EndGroup();

    }

    void OpenLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
