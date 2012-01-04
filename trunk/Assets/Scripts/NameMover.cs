using UnityEngine;
using System.Collections;

public class NameMover : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(networkView.isMine)
		{
			if(!GameObject.Find("Player1(Clone)").Equals(null))
			{
				GameObject.Find("PlayerName(Clone)").transform.position = new Vector3(GameObject.Find("Player1(Clone)").transform.position.x, GameObject.Find("Player1(Clone)").transform.position.y + 2, GameObject.Find("Player1(Clone)").transform.position.z);
			}
			
			if(!GameObject.Find("Player2(Clone)").Equals(null))
			{
				GameObject.Find("PlayerName(Clone)").transform.position = new Vector3(GameObject.Find("Player2(Clone)").transform.position.x, GameObject.Find("Player2(Clone)").transform.position.y + 2, GameObject.Find("Player2(Clone)").transform.position.z);
			}
			
			if(!GameObject.Find("Player3(Clone)").Equals(null))
			{
				GameObject.Find("PlayerName(Clone)").transform.position = new Vector3(GameObject.Find("Player3(Clone)").transform.position.x, GameObject.Find("Player3(Clone)").transform.position.y + 2, GameObject.Find("Player3(Clone)").transform.position.z);
			}
			
			if(!GameObject.Find("Player4(Clone)").Equals(null))
			{
				GameObject.Find("PlayerName(Clone)").transform.position = new Vector3(GameObject.Find("Player4(Clone)").transform.position.x, GameObject.Find("Player4(Clone)").transform.position.y + 2, GameObject.Find("Player4(Clone)").transform.position.z);
			}
		}
		
		
	}
}
