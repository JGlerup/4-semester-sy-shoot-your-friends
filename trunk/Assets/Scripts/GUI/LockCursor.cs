using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
	}


    //Tjekker om spillet er sat på pause.
    //True, alle gui elementer deaktiveres og tiden bliver sat i stå
    //False, alle gui elementer genaktiveres, samt kører igen (1.0f)
    //Tegner desuden pause-menuen
    void SetPause()
    {
        PauseMenu pm = (PauseMenu)GetComponent(typeof(PauseMenu));
        pm.enabled = true;
    }

	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButton(0))
        //    Screen.lockCursor = true;
        if (Input.GetKeyDown("escape"))
        {
            Screen.lockCursor = false;
            SetPause();
        }
        //// Did we lose cursor locking?
        //// eg. because the user pressed escape
        //// or because he switched to another application
        //// or because some script set Screen.lockCursor = false;
        //if (!Screen.lockCursor && wasLocked)
        //{
        //    wasLocked = false;
        //    SetPause();
        //}
        //// Did we gain cursor locking?
        //else if (Screen.lockCursor && !wasLocked)
        //{
        //    wasLocked = true;
        //}
	}
}
