using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamInput : MonoBehaviour {

	public AudioClip aud;
	public int minFreq = 0;
	public int maxFreq = 0;

	public GameObject soundwave;

	void Awake(){
		aud = Microphone.Start("Built-in Microphone", true, 5, 44100);
	}

	// Use this for initialization
	void Start () {
		
		//Debug.Log("Device caps: " + minFreq.ToString() + ", " + maxFreq.ToString());

		
		//Debug.Log("Is the mic recording? " + Microphone.IsRecording("Built-in Microphone"));


	}
	
	// Update is called once per frame
	void Update () {
		//get mic volume
		int dec = 128;
		float[] waveData = new float[dec];
		int micPosition = (Microphone.GetPosition(null))-(dec+1); // null means the first microphone
		//Debug.Log("waveData: " + waveData.ToString());
		aud.GetData(waveData, micPosition);

		// Getting a peak on the last 128 samples
		float levelMax = 0;
		for (int i = 0; i < dec; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
		//Debug.Log("Current input level: " + level);
		if(level > 0.6f){
			Instantiate(soundwave, transform.position, transform.rotation);
			//Debug.Log("AAAAAAAAAAA");
		}
	}
}
