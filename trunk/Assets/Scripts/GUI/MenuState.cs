using UnityEngine;
using System.Collections;

public class MenuState : MonoBehaviour {
    public bool PlayerIsDead { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") && !PlayerIsDead)
        {
            DrawPauseMenu();
        }
	}

    void DrawPauseMenu()
    {
        GameObject go = GameObject.Find("GUI");
        PauseMenu pM = (PauseMenu)go.GetComponent(typeof(PauseMenu));
        pM.enabled = true;
    }

    public void DrawHighscoreMenu()
    {
        GameObject go = GameObject.Find("GUI");
        HighscoreMenu hM = (HighscoreMenu)go.GetComponent(typeof(HighscoreMenu));
        hM.enabled = true;
    }
}
