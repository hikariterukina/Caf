using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player:NetworkBehaviour {
    public float move = 0.3f;
    public float rotate = 3f;
    public float JumpForce = 10f;
    public GameObject[] Players;
    public GameObject fleaPlayer;

    [ClientCallback]
    public void Update() {
        if (!isLocalPlayer) {
            return;
        }

        Players = GameObject.FindGameObjectsWithTag("Player");
        fleaPlayer = GameObject.FindWithTag("fleaPlayer");      

        //Playerの視点操作
        float z = Input.GetAxis("Horizontal");                      
        transform.Rotate(0, z * rotate, 0);

        float x = Input.GetAxis("Vertical");
        //Playerにノミがある時ない時の操作
        if (gameObject.tag == "Player") {
            transform.Translate(0, 0, x * move);
        } else if (gameObject.tag == "fleaPlayer") {
            transform.Translate(0, 0, x * move * 1.05f);
        }             
    }

    [ClientCallback]
    void OnTriggerStay(Collider other) {
        //Playerのジャンプ
        if (Input.GetKeyDown(KeyCode.Space)) {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(0,1*JumpForce,0);
        }                            
    }
    
    [ClientCallback]
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && gameObject == fleaPlayer) {
            for (int i = 0; i <= Players.Length; i++) {
                if (other.gameObject == Players[i]) {
                    print(Players);
                }
            }
        }
    }
}