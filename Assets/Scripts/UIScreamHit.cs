using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreamHit : MonoBehaviour {
	public void CollisionHit ()
	{
		GameObject.FindObjectOfType<GameManager>().StartGame();
	}
}
