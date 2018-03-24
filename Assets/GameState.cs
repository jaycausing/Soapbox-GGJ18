using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- Starts and ends game
- Keeps track of player hurt level
 */

public class GameState : MonoBehaviour {

	bool isStarted;
	public int hurtLevel;
	GameManager gm;
	UpdateSky upSky;

	/*
	- append Soapbox logo to front of player
	 */
	void Start () {
		
	}
	
	/*
	- when logo collides with soundwave, start game
	*/
	void Update () {
		
	}

	void startGame (){
		isStarted = true;
		hurtLevel = 0;
		upSky.bg.backgroundColor = startColor;
	}

	void endGame () {
		isStarted = false;
	}

}
