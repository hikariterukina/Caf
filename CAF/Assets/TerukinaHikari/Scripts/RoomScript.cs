using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RoomScript : NetworkBehaviour {
    Canvas canvas;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RoomReadyOkButton()
    {
        this.gameObject.SetActive(false);
    }
}
