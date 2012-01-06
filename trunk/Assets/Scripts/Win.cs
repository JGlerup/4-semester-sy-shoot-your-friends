using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Win : MonoBehaviour {
	
	public int winningTeamNumber;
	
	
	// Use this for initialization
	void Start () {
		winningTeamNumber = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(winningTeamNumber == 0)
		{
			
		}
		else
		{
			if(winningTeamNumber == 1)
			{
				//Win1();
			}
			if(winningTeamNumber == 2)
			{
				//Win2();
			}
			if(winningTeamNumber == 3)
			{
				//Win3();
			}
			if(winningTeamNumber == 4)
			{
				//Win4();
			}
		}
	
	}
	
	
}
