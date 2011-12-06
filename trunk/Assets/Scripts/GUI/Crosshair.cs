using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
    public Texture2D crosshairTexture;


	// Use this for initialization
	void Start () {
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width /2, Screen.height / 2, crosshairTexture.width / 2, crosshairTexture.height /2), crosshairTexture);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
