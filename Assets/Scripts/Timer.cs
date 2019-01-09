using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	private bool isActive;
	private float timeLimit;
	private float timeRemaining;

	private Camera playerCam;
	private Color startColor = new Color(0.55f, 0.88f, 1f, 1f);
	private Color endColor = new Color(1f, 0.52f, 0f, 1f);

    public float TimeRemaining { get { return timeRemaining; } }

	public void StartTimer (float tl)
	{
		timeLimit = tl;
		timeRemaining = timeLimit;
		isActive = true;
	}

	void Update () {
		if (isActive && timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
			playerCam.backgroundColor = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, timeRemaining)/timeRemaining);
		}
		else if (isActive && timeRemaining <= 0)
		{
			GetComponent<InGameState>().EndLevel();
			//StopTimer();
		}
	}

	public void StopTimer ()
	{
		isActive = false;
	}
}
