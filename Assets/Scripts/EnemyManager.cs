using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject world;
	public int pplCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject bad;

	void Start () {
		world = GameObject.FindWithTag("World");		
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
		
		float ang = Random.value * 360;
        Vector3 pos;
        pos.x = wCenter.x + 40 * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = wCenter.y;
        pos.z = wCenter.z + 40 * Mathf.Cos(ang * Mathf.Deg2Rad);
        //Debug.Log("Spawn position: " + pos);

		return pos;
	}
}
