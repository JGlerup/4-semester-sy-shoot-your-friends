using UnityEngine;
using System.Collections;

public class NetworkCamera : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		if(networkView.isMine)
		{
			gameObject.transform.camera.enabled = true;
		}
		else
		{
			gameObject.transform.camera.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
