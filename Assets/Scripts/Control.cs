using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(20, 100, 50,50), "Start"))
		{
			GameObject.Find("Player(Clone)").transform.position = new Vector3(25,2,60);
			GameObject.Find("PlayerName(Clone)").transform.position = new Vector3(25,2,60);
		}
	}
}
