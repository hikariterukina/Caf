using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childtest : MonoBehaviour {
	public GameObject flea;
    public float move = 0.3f;
    BoxCollider[] boxcolliders;

	void Start(){
		flea = transform.Find("flea").gameObject;
        boxcolliders = GetComponents<BoxCollider>();
        boxcolliders[1].enabled = false;                                
    }

    void Update () {
		float x = Input.GetAxis("Horizontal");
        //Playerにノミがある時ない時の操作
        if (transform.Find("flea").gameObject.activeSelf) {
            transform.Translate(x * move * 2.5f, 0, 0);
        } else {
            transform.Translate(0, 0, 0);
            boxcolliders[1].enabled = false; 
        }
    }

    private void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player") {
            if (transform.Find("flea").gameObject.activeSelf) {
                flea.SetActive(false);
            } else {
                flea.SetActive(true);
            }
        }
    }

    public void touch() {
        if(transform.Find("flea").gameObject.activeSelf)
        boxcolliders[1].enabled = true;
    }

    public void leave() {
        if (transform.Find("flea").gameObject.activeSelf)      
            boxcolliders[1].enabled = false;
    }
}