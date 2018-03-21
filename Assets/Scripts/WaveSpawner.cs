using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject SoundWave;
    ScreamInput AAAA; 

	// Use this for initialization
	void Start () {
        AAAA = gameObject.GetComponentInParent<ScreamInput>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void generateRings()
    {
        if (AAAA.activeScream == true)
        {
            GameObject wave = Instantiate(SoundWave, transform.position, transform.rotation); 
            Vector3 force = transform.forward * 5.0f;
            wave.GetComponent<Rigidbody>().AddForce(force);

        }
    }

}
