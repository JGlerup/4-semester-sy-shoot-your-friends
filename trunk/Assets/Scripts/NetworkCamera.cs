using UnityEngine;
using System.Collections;

public class NetworkCamera : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
        AudioListener audioListener = (AudioListener)this.GetComponent(typeof(AudioListener));

		if(networkView.isMine)
		{
            audioListener.enabled = true;
			gameObject.transform.camera.enabled = true;
		}
		else
		{
            audioListener.enabled = false;
			gameObject.transform.camera.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
