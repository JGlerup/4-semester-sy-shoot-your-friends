using UnityEngine;
using System.Collections;

public class SetupServer : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    public void LaunchServer(int connections, int listenPort)
    {
        bool useNat = !Network.HavePublicAddress();
        Network.InitializeServer(connections, listenPort, useNat);
        MasterServer.RegisterHost("ShootYourFriends", "JohnDoes game", "l33t game for all");
        Debug.Log("Server created " + MasterServer.ipAddress);
        Application.LoadLevel("City1");
        StartCoroutine(SetupNetworkObjects(2.0F));
    }

    void OnConnectedToServer()
    {
        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
        {
            go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
        }
    }

    private IEnumerator SetupNetworkObjects(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
        {
            go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
        }
    }
}
