using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player:NetworkBehaviour {
    public float move = 0.3f;
    public float rotate = 3f;
    public float JumpForce = 10f;
    public GameObject flea;
    BoxCollider[] boxColliders;

    void Awake() {
        flea = gameObject.transform.Find("flea").gameObject;
        boxColliders = GetComponents<BoxCollider>();
        boxColliders[1].enabled = false;
    }

    private void Start() {
        if (!isLocalPlayer)
            return;
        Camera.main.transform.parent = gameObject.transform;

        Camera.main.transform.position =
        new Vector3(gameObject.transform.position.x,
        gameObject.transform.position.y + 1,
        gameObject.transform.position.z - 3);
    }

    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public override void OnStartServer() {
        base.OnStartServer();
    }

    [ClientCallback]
    void FixedUpdate() {
        if (!isLocalPlayer)
            return;
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
            boxColliders[1].enabled = false;
        }
    }

    [ClientCallback]
    void OnTriggerStay(Collider other) {
        if (!isLocalPlayer)
            return;
        //Playerのジャンプ
        if (Input.GetKeyDown(KeyCode.Space)) {
            float y = JumpForce;
            CmdJump(y);
        }
    }

    [Command]
    public void CmdJump(float y) {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(0, 1 * y, 0);
    }

    [ClientCallback]
    void OnTriggerEnter(Collider hit) {
        if (!isLocalPlayer)
            return;
        if (hit.gameObject.tag == "Player") {
            if (transform.Find("flea").gameObject.activeSelf) {
                flea.SetActive(false);
            } else {
                flea.SetActive(true);
            }
        }
    }                       

    public void touch() {
        if (transform.Find("flea").gameObject.activeSelf)
            boxColliders[1].enabled = true;
    }

    public void leave() {
        if (transform.Find("flea").gameObject.activeSelf)
            boxColliders[1].enabled = false;
    }
}