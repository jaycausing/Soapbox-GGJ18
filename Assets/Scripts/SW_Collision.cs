﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SW_Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		Debug.Log("COLLIDED WITH: " + c.gameObject);
		if(c.gameObject.tag == "Bad"){
			Destroy(c.gameObject);
		}
	}
}
