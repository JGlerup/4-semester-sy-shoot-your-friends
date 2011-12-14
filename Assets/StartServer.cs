using UnityEngine;
using System.Collections;
using System;

public class StartServer : MonoBehaviour 
{	
	// Use this for initialization
	void Start () 
	{	
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public string remoteIP = "127.0.0.1";
	public int remotePort = 25000;
	public int listenPort = 25000;
	public bool useNAT = false;
	public string yourIP = "";
	public string yourPort = "";
	
	//Starting the Main Menu
	void OnGUI () 
	{
 		// Checking if you are connected to the server or not
 		if (Network.peerType == NetworkPeerType.Disconnected)
  		{
  			// If not connected
     		if (GUI.Button (new Rect(10,10,100,30),"Connect"))
  			{
				//Starting level
				Application.LoadLevel("City1");
				
   				// Connecting to the server
   				Network.Connect(remoteIP, remotePort);
				
  			}//end if
  
			if (GUI.Button (new Rect(10,50,100,30),"Start Server"))
  			{   				
   				
				//Starting level
				Application.LoadLevel("City1");
				
				// Creating server
   				Network.InitializeServer(32, listenPort, useNAT);
				
   				// Notify our objects that the level and the network is ready
   				foreach(GameObject go in FindObjectsOfType(typeof(GameObject)))
   				{
    				go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver); 
   				}//end foreach
  			}//end if
   
  			// Fields to insert ip address and port 
  			remoteIP = GUI.TextField(new Rect(120,10,100,20),remoteIP);
  			remotePort = Convert.ToInt32(GUI.TextField(new Rect(230,10,40,20),remotePort.ToString()));
  		}//end if
 		else
  		{
			
  			// Getting your ip address and port
  			yourIP = Network.player.ipAddress;
  			yourPort = Network.player.port.ToString();
   
//  			GUI.Label(new Rect(140,20,250,40),"IP Adress: "+yourIP+":"+yourPort);
//			GUI.Label(new Rect(140,40,250,40),"Connections: " + Network.connections.Length);
            if(Network.connections.Length >= 1)
			{
				GUI.Label(new Rect(20,20,250,40),"Ping To Server: " + Network.GetAveragePing(Network.connections[0]));
			}//end if
			
			if (GUI.Button (new Rect(10,10,100,50),"Disconnect"))
  			{
   				// Disconnect from the server
   				Network.Disconnect(200);
  			}//end if
  		}//end else
	}
	
	//Tells everyone that you are connected and object should be loaded
    void OnConnectedToServer()
    {
        foreach(GameObject go in FindObjectsOfType(typeof(GameObject)))
        {
            go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
        }//end foreach
    }
}