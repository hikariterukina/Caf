using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player:NetworkBehaviour {
    public float move = 0.3f;
    public float rotate = 3f;
    public float JumpForce = 10f;
    public GameObject flea;

    void Awake() {
        flea = gameObject.transform.Find("flea").gameObject;
    }

    public override void OnStartLocalPlayer() {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    [ClientCallback]
    void FixedUpdate() {
        //Playerの視点操作
        float z = Input.GetAxis("Horizontal");                 
        float x = Input.GetAxis("Vertical");
        CmdMove(x, z);                      
    }

    [Command]
    public void CmdMove(float x, float z) {
        transform.Rotate(0, z * rotate, 0);   
        //Playerにノミがある時ない時の操作               
        if (transform.Find("flea").gameObject.activeSelf) {
            transform.Translate(0, 0, x * move * 1.05f);
        } else {
            transform.Translate(0, 0, x * move);
        }
    }

    [ClientCallback]
    void OnTriggerStay(Collider other) {
        //Playerのジャンプ
        if (Input.GetKeyDown(KeyCode.Space)) {
            float y = JumpForce;
            CmdJump(y);
        }                            
    }

    [Command]
    public void CmdJump(float y) {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(0, 1 * y , 0);
    }
    
    [ClientCallback]
    void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.tag == "Player") {
            if (transform.Find("flea").gameObject.activeSelf) {
                flea.SetActive(false);
            } else {
                flea.SetActive(true);
            }
        }
    }
}