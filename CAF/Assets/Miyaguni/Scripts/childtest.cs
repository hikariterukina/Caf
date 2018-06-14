using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childtest : MonoBehaviour {
	public GameObject flea;
    public float move = 0.3f;

	void Start(){
		flea = transform.Find("flea").gameObject;
	}

	void Update () {
		float x = Input.GetAxis("Horizontal");
        //Playerにノミがある時ない時の操作
        if (transform.Find("flea").gameObject.activeSelf) {
            transform.Translate(x * move * 2.5f, 0, 0);
        } else {
            transform.Translate(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.tag == "Player") {
            if (transform.Find("flea").gameObject.activeSelf) {
                flea.SetActive(false);
            } else {
                flea.SetActive(true);
            }
        }
    }
}