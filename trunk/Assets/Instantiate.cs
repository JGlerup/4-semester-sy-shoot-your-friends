using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour 
{
	
	public Transform gamePlayer;
//	public Transform house;
//	public Transform bigTree;
//	public Transform text;
	public Vector3 location = new Vector3(23.6671f,3f,57.98985f);
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
		
	void OnNetworkLoadedLevel() 
	{
 		// Instantiating cube when Network is loaded
//		TextMesh t = (TextMesh)text.GetComponent(typeof(TextMesh));
//		t.text = "" + Network.player.ipAddress + "";
 		Network.Instantiate(gamePlayer, location, transform.rotation, 0);
//		Network.Instantiate(house, transform.position, transform.rotation, 0);
//		Network.Instantiate(bigTree, transform.position, transform.rotation, 0);
//		Network.Instantiate(text, location1, transform.rotation, 0);
	}
	
	void OnPlayerDisconnected(NetworkPlayer player) 
	{
 		Network.RemoveRPCs(player, 0);
 		Network.DestroyPlayerObjects(player);
	}
}
