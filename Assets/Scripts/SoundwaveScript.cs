using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwaveScript : MonoBehaviour {

	Rigidbody rb;
	public float timeAlive = 0;
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		rb.AddForce(transform.forward * 5);
		timeAlive += Time.fixedDeltaTime;
		if(timeAlive >= 5){
			Destroy(this);
		}
	}

	private void OnCollisionEnter(Collision other) {
		other.gameObject.BroadcastMessage("CollisionHit");
		Destroy(this);
	}
}
