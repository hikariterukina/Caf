using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorTest : MonoBehaviour {
	public static GameObject[] fleas;

	void Start(){
        if (fleas.Length >= 2) {
            fleaSelect();
        }
	}

    void fleaSelect () {
        fleas = GameObject.FindGameObjectsWithTag("flea");

        fleas[Random.Range(0, fleas.Length)].SetActive(false);
    }
}
