using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;

public class Player_1:MonoBehaviour {
    public float speed = 0.3f;
    public float rotate = 3f;
    public float JumpForce = 10f;
    //public GameObject flea;

    public Rigidbody rb;

    //一時的に追加
    bool Upush = false;
    bool Dpush = false;
    bool Rpush = false;
    bool Lpush = false;

    void Awake() {
        //flea = gameObject.transform.Find("flea").gameObject;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*public override void OnStartLocalPlayer() {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }*/
    public void UpMoveKey()
    {
        Upush = true;
       Debug.Log("ok");
       // this.transform.position += new Vector3(0, 0, 1 * move);
    }

    public void UpMoveKeyUp()
    {
        Upush = false;
    }

    void Update() {
        /*    if (!isLocalPlayer)
                return;*/
        if (Upush == true)
        {
            Move();
        }

        Debug.Log(Upush);

        //Playerの視点操作
        float z = Input.GetAxis("Horizontal");                      
        transform.Rotate(0, z * rotate, 0);

        float x = Input.GetAxis("Vertical");
        //Playerにノミがある時ない時の操作
        /*if (transform.Find("flea").gameObject.activeSelf) {
            transform.Translate(0, 0, x * speed * 1.05f);
        } else {
            transform.Translate(0, 0, x * speed);
        }*/

        
    }

    public void Move()
    {
        //this.transform.position += new Vector3(0, 0, 1 * speed);
        rb.AddForce(0, 0, speed * 1);
    }

    void OnTriggerStay(Collider other) {
        /*if (!isLocalPlayer)
            return;*/

        //Playerのジャンプ
        if (Input.GetKeyDown(KeyCode.Space)) {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rb.AddForce(0,1*JumpForce,0);
        }                            
    }
    
    void OnCollisionEnter(Collision hit) {
        /*if (!isLocalPlayer)
            return;*/

        /*if (hit.gameObject.tag == "Player") {
            if (transform.Find("flea").gameObject.activeSelf) {
                flea.SetActive(false);
            } else {
                flea.SetActive(true);
            }*/
        }
    }


