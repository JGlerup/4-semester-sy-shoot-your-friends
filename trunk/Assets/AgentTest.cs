using UnityEngine;
using System.Collections;
using Behave.Runtime;
using Tree = Behave.Runtime.Tree;

public class AgentTest : MonoBehaviour, IAgent {

    public bool isPlayerFound = false;
        
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Reset(Tree sender)
    {
        throw new System.NotImplementedException();
    }

    public int SelectTopPriority(Tree sender, params int[] IDs)
    {
        throw new System.NotImplementedException();
    }

    public BehaveResult Tick(Tree sender, bool init)
    {
        throw new System.NotImplementedException();
    }
}
