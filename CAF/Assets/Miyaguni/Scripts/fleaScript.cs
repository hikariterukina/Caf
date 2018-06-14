using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class fleaScript : NetworkBehaviour {
    void Update(){
		transform.position = 
		new Vector3(gameObject.transform.parent.position.x,
		gameObject.transform.parent.position.y+1.5f,
		gameObject.transform.parent.position.z);
     }
}
