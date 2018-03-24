using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSky : MonoBehaviour {

	Camera bg;
	public Color startColor = new Color(0.55f, 0.88f, 1f, 1f);
	public Color endColor = new Color(1f, 0.52f, 0f, 1f);
	public GameManager gm;
	float t;
	public float currentTimeLeft;
	GameState gs;

	void Awake () {
		bg = GameObject.Find("Main Camera").GetComponent<Camera>();
		t = gm.timeLeft;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gs.isStarted){
			currentTimeLeft = gm.timeLeft;
			if(currentTimeLeft > 0.0f){
				bg.backgroundColor = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, t)/t);
			} else {
				gs.endGame();
			}
		}
		
	}
}
