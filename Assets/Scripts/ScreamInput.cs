using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamInput : MonoBehaviour {

	AudioSource aud;
	int minFreq = 0;
	int maxFreq = 0;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource>();
		foreach (string device in Microphone.devices) {
            Debug.Log("Name: " + device);
        }
		Microphone.GetDeviceCaps("Built-in Microphone", out minFreq, out maxFreq);
		Debug.Log("Device caps: " + minFreq.ToString() + ", " + maxFreq.ToString());

		aud.clip = Microphone.Start("Built-in Microphone", true, 5, 44100);
		Debug.Log("Is the mic recording? " + Microphone.IsRecording("Built-in Microphone"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
