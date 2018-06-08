using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManagerButton : NetworkBehaviour {
    public Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnRoomHostButton()
    {
        canvas.gameObject.SetActive(false);
        NetworkManager.singleton.StartHost();
    }

    public void OnClientButton()
    {
        canvas.gameObject.SetActive(false);
        NetworkManager.singleton.StartClient();
    }
}
