using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- Starts and ends game
- Keeps track of player hurt level
 */

public abstract class GameState : MonoBehaviour {

	//public enum GameStates { Title, Game, End }
	private bool isActive = false;
	public bool IsActive
	{ get { return isActive; } }

    private void Start () {
        EnterState();
    }
    private void OnDisable() {
        ExitState();
    }

	public abstract void EnterState ();
	public abstract void ExitState ();

}

public class TitleState : GameState
{
	public GameObject titleLogo;
	//public Animator logoAnimator;

    public override void EnterState()
    {
        if (titleLogo == null)
            titleLogo = GameObject.Find("Title Canvas");

        titleLogo.SetActive(true);
       // GameManager.GameStartEvent += ExitState;
    }

    public override void ExitState()
    {
        if (titleLogo != null)
        {
            titleLogo.SetActive(false);
           // GameManager.GameStartEvent -= ExitState;
        }
    }
}

public class InGameState : GameState {

    private GameManager gameManager;
    private EnemyManager enemyManager;

    #region LEVEL VARIABLES
    private Level currentLevel;
    private float timeRemaining;

    public float TimeRemaining { get { return timeRemaining; } }
    #endregion

    public override void EnterState()
    {
        gameManager = GetComponentInParent<GameManager>();
        enemyManager = gameObject.AddComponent<EnemyManager>();
    }

    public void StartLevel ()
    {
        // Activate enemy spawner
        // Start timer countdown
    }

    public void NextLevel ()
	{
        //  TODO: Implement progressive difficulty curve generator for each incremental level
        currentLevel = new Level(60, 10, 10, 10);
        gameManager.ThisLevel = currentLevel;
	}

    public void EndLevel ()
    {
        // Reset any cooldowns
        // Stop and deactivate enemy spawner
        // Stop timer countdown
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    private void Countdown ()
	{
		timeRemaining -= Time.deltaTime;
		//TODO: Exit timer after game over
		if(timeRemaining <= 0){
			Debug.Log("Times Up");
		}
	}
}

public class EndState : GameState
{
	public GameObject endGameCanvas;

    public override void EnterState()
    {
        endGameCanvas = GameObject.Find("End Canvas");
        endGameCanvas.SetActive(true);
    }

    public override void ExitState()
    {
        endGameCanvas.SetActive(true);
    }
}