using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorTest : MonoBehaviour {
	public static GameObject[] fleas;

	void Start(){
        fleas = GameObject.FindGameObjectsWithTag("flea");

        if (fleas.Length >= 2) {
            fleaSelect();
        }
	}

    void fleaSelect () {                                                     
        fleas[Random.Range(0, fleas.Length)].SetActive(false);
    }
}
