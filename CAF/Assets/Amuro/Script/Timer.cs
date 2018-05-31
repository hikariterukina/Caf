using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float time = 60;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		CountTime();
	}

	public void CountTime()
	{
		time -= Time.deltaTime;
		GetComponent<Text>().text = time.ToString("F0");

		if (time <= 0)
		{
			enabled = false;

			Invoke("Change", 2);
		}
	}

	public void Change()
	{
		SceneManager.LoadScene("xxxx");
	}



}
