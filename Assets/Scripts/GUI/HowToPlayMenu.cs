using UnityEngine;
using System.Collections;

public class HowToPlayMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 120, 300, 250));
        GUI.Box(new Rect(0, 0, 300, 250), "How to Play");
        GUI.TextField(new Rect(25, 25, 100, 30), "Placeholder");

        if (GUI.Button(new Rect(55, 200, 180, 40), "Exit to Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }
        GUI.EndGroup();
    }
}
