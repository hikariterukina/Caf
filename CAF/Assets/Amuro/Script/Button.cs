using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject player;
	public float move = 0;
    public float rotate = 0;
    public float JumpForce = 10f;

    private Vector3 prev;

    bool Upush = false;
    bool Dpush = false;
    bool Rpush = false;
    bool Lpush = false;

    // Use this for initialization
    void Start () {
        prev = player.transform.position;

        //Player内のUpdate()を読み取る
        /*int size = Players.Length;
        for (int i = 0; i < size; i++) 
        {
            Players[i].GetComponent<Player>().Update();
        }*/
	}
	
	// Update is called once per frame
	void Update () {

        if (Upush == true)
        {
            prev += new Vector3(0, 0, 1 * move);
        }
        else if (Dpush == true)
        {
            gameObject.transform.Translate(0, 0, -1 * move);
        }
        else if (Rpush == true)
        {
            gameObject.transform.Rotate(0, 1 * rotate, 0);
        }
        else if (Lpush == true)
        {
            gameObject.transform.Rotate(0, -1 * rotate, 0);
        }

      //  Debug.Log(Upush);
	}	
	

	public void UpButtonPush()
    {
        Upush = true;
        Debug.Log("ok");
    }

	public void DownButtonPush()
    {
        Dpush = true;
    }

	public void RightButtonPush()
    {
        Rpush = true;
    }

	public void LeftButtonPush()
    {
        Lpush = true;
    }
	
}
