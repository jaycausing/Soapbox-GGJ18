using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- spawn enemies
- keeps track of player's points
 */

public class GameManager : MonoBehaviour {

	[SerializeField]
	private int score;
	[SerializeField]
	public static GameState CurrentState;

	private Stack<Level> levels = new Stack<Level>();

	public delegate void GameStart ();
	public delegate void GameEnd ();
	public static event GameStart GameStartEvent;
	public static event GameEnd GameEndEvent;

	public int CurrentLevel { get { return levels.Count; } }
	public Level ThisLevel { 
		get { return levels.Peek(); } 
		set { levels.Push(value); }
	}

	public int CurrentScore {
		get { return score; }
		set { score += value; }
	}

	void OnEnable(){
		
	}

	void Start () {

		//Collider wCollider = world.GetComponent<Collider>();
		//if(activeSpawn)
			//StartCoroutine(SpawnEnemy());

		/*AudioSource aud = GetComponent<AudioSource>;
		aud.clip = Microphone.Start*/

		
	}

	private void InitGame ()
	{
		CurrentState = gameObject.AddComponent<TitleState>();
	}

	public void StartGame ()
	{
		Destroy(CurrentState);
		CurrentState = gameObject.AddComponent<InGameState>();
	}

	public void ClearScore ()
	{
		score = 0;
	}
	
}
