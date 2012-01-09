using UnityEngine;
using System.Collections;

public class VictoryText : MonoBehaviour 
{
	public string WinningTeam{ get; set; }

	// Use this for initialization
	void Start () 
	{
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		float areaWidth = 200;
        float areaHeight = 200;
        float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
        GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth,
        areaHeight));

        GUILayout.Label("The Winning Team Is : " + WinningTeam);
        GUILayout.EndArea();
	}
}
