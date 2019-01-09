using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSky : MonoBehaviour {

	Camera playerCam;
	public Color startColor = new Color(0.55f, 0.88f, 1f, 1f);
	public Color endColor = new Color(1f, 0.52f, 0f, 1f);
	public GameManager gameManager;

	void Awake () {
		playerCam = Camera.main;
	}

	void Start () {
		
	}
	
	void Update () {
		float remainingTime = FindObjectOfType<InGameState>().TimeRemaining;
		if(remainingTime > 0.0f){
			playerCam.backgroundColor = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, remainingTime)/remainingTime);
		} else {
			//gs.endGame();
		}
	}
		
}

