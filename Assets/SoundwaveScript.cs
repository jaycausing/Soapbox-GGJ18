using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwaveScript : MonoBehaviour {

	Rigidbody rb;
	public int timeToLive;
	public int timeAlive;
	public float speed;
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}
	
	// Use this for initialization
	void Start () {
		timeAlive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(transform.forward * speed);
		timeAlive++;
	}

	void LateUpdate(){
		if(timeAlive >= timeToLive){
			Destroy(this);
		}
	}
}
