using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameDirector : NetworkBehaviour {
    public GameObject[] Players;
    public GameObject[] fleas;

    bool one;

    void Start(){
        Players = GameObject.FindGameObjectsWithTag("Player");
        fleas = GameObject.FindGameObjectsWithTag("flea");
    }

    private void Update() {
        Players = GameObject.FindGameObjectsWithTag("Player");
        fleas = GameObject.FindGameObjectsWithTag("flea");

        if (Players.Length >= 2 && one) {
            fleas[Random.Range(0, fleas.Length)].SetActive(false);
            one = false;
        }
    }
}