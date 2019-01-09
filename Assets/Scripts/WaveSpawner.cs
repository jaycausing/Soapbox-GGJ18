using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public float Speed = 5.0f;

    public GameObject SoundWave;
    ScreamInput AAAA; 

	void Awake () {
        AAAA = gameObject.GetComponentInParent<ScreamInput>();
    }

    public void generateRings(){
        if (AAAA.IsScreaming == true){
            Debug.Log("Launching rings");
            GameObject wave = Instantiate(SoundWave, transform.position, transform.rotation); 
            Vector3 force = transform.forward * Speed;
            wave.GetComponent<Rigidbody>().AddForce(force);
            AAAA.IsScreaming = false;
        }
    }

}
