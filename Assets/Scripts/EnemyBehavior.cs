using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {

	public Transform playerPos;

	void Awake(){
		GameObject p = GameObject.FindWithTag("Player");
		playerPos = p.transform;
	}

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = playerPos.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
