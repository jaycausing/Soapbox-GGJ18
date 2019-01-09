using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamInput : MonoBehaviour {

	public AudioClip aud;
	private string device;
	public int minFreq = 0;
	public int maxFreq = 0;

	private int dec = 128;

    public bool IsScreaming 
	{ 
		get { return IsScreaming; } 
		set { IsScreaming = value; }
	} //lets the other scripts know if screaming 
	//public GameObject soundwave;

	//bool isInitialized;

	private void Awake() {
		IsScreaming = false;
	}

	void OnEnable(){
		aud = Microphone.Start("Built-in Microphone", true, 5, 44100);
		//isInitialized = true;
	}

	// Use this for initialization
	void Start () {
		
		//Debug.Log("Device caps: " + minFreq.ToString() + ", " + maxFreq.ToString());

		
		//Debug.Log("Is the mic recording? " + Microphone.IsRecording("Built-in Microphone"));


	}
	
	
	void Update () {
		float levelMax = 0;
		//get mic volume
		float[] waveData = new float[dec];
		int micPosition = (Microphone.GetPosition(null))-(dec+1); // null means the first microphone
		//Debug.Log("waveData: " + waveData.ToString());
		aud.GetData(waveData, micPosition);

		// Getting a peak on the last 128 samples
		for (int i = 0; i < dec; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
		//Debug.Log("Current input level: " + level);
		if(level > 0.6f){
            IsScreaming = true;  //is screaming 
            WaveSpawner spawn = gameObject.GetComponentInChildren<WaveSpawner>(); //references the spawn script to start spawning
            spawn.generateRings(); 
			//Instantiate(soundwave, transform.position, transform.rotation);
			Debug.Log("AAAAAAAAAAA");
		} else {
			IsScreaming = false;
		}
	}
}
