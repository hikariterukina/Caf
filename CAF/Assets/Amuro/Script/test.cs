using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	public float speed = 100f;
    public float rotate = 10f;
    public float JumpForce = 10f;
    Rigidbody rb;
    Collider col;
    public int jumpow = 1;

    bool Upush = false;
    bool Rpush = false;
    bool Lpush = false;
    bool Dpush = false;
    bool Jpush = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    void Update()
    {
       /* float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;*/
        if(Upush == true)
        {
            transform.Translate(0, 0, 1 * speed * Time.deltaTime);
        }

        if (Dpush == true)
        {
            transform.Translate(0, 0, -1 * speed * Time.deltaTime);
        }

        if (Rpush == true)
        {
            transform.Rotate(0, 1 * rotate * Time.deltaTime, 0);
        }

        if (Lpush == true)
        {
            transform.Rotate(0, -1 * rotate * Time.deltaTime, 0);
        }

        if(jumpow == 1 && Jpush == true)
        {
            jumpow--;
            rb.AddForce(0, 1 * JumpForce, 0);
            
        }
        print(jumpow);
        print(Jpush);
        
    }

    public void buttondown()
    {
        Upush = true;
    }

    public void buttonup()
    {
        Upush = false;
    }

    public void Dbuttondown()
    {
        Dpush = true;
    }

    public void Dbuttonup()
    {
        Dpush = false;
    }

    public void Rbuttondown()
    {
        Rpush = true;
    }

    public void Rbuttonup()
    {
        Rpush = false;
    }

    public void Lbuttondown()
    {
        Lpush = true;
    }

    public void Lbuttonup()
    {
        Lpush = false;
    }

    public void spacebuttondown()
    {
        Jpush = true;  
        //rb.AddForce(0, 1 * JumpForce, 0);
    }

    public void spacebuttonup()
    {
        Jpush = false;
        //jumpow = 1;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "plane")
        {
            jumpow = 1;
        }

    }
}
