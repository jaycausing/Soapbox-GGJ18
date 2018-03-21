using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float timeLeft = 60;
	public GameObject world;
	public int pplCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject bad;
	public bool activeSpawn = false;

	void Awake(){
		world = GameObject.FindWithTag("World");
	}


	// Use this for initialization
	void Start () {

		//Collider wCollider = world.GetComponent<Collider>();
		if(activeSpawn)
			StartCoroutine(SpawnEnemy());

		/*AudioSource aud = GetComponent<AudioSource>;
		aud.clip = Microphone.Start*/

		
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: put all this in a seperate function for after starting in game
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0){
			Debug.Log("Times Up");
		}
	}

	IEnumerator SpawnEnemy(){
		Collider wCollider = world.GetComponent<Collider>();
		yield return new WaitForSeconds(startWait);
		while(true){
			for (int i = 0; i < pplCount; i++)
            {
                Vector3 spawnPos = getSpawnCircumference(wCollider);
                Quaternion spawnRotation = Quaternion.identity;
				//TODO: rotate enemy sprite towards player when spawning
                Instantiate (bad, spawnPos, spawnRotation);
				Debug.Log("Spawning");
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
		}
	}

	Vector3 getSpawnCircumference(Collider c){
		Vector3 wCenter = c.bounds.center;
		//Vector3 wMin = c.bounds.min;
		//Debug.Log("Center of sphere: " + wCenter);
		//Debug.Log("Max bounds of sphere: " + wMin);
		/*
		max: 40, 0, 40
		center: 0, -40, 0
		min: -40, -80, -40
		spawn coords: x, -40, z
		 */
		float ang = Random.value * 360;
        Vector3 pos;
        pos.x = wCenter.x + 40 * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = wCenter.y;
        pos.z = wCenter.z + 40 * Mathf.Cos(ang * Mathf.Deg2Rad);
        //Debug.Log("Spawn position: " + pos);

		return pos;
	}
}
