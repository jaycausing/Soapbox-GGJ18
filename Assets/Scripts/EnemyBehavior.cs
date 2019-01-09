using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBehavior : MonoBehaviour {

	[Range (1, 30)]
	public float movementSpeed = 5;

	[SerializeField][Range (1, 5)]
	private int points;

	[SerializeField]
	private Animator enemyAnimator;

	[SerializeField]
	private Transform playerPos;
	private Transform world;


	public int Points {
		get { return points; }
	}

	void Awake(){
		world = GameObject.FindWithTag("World").transform;
		Physics.IgnoreCollision(world.GetComponent<Collider>(), GetComponent<Collider>());
	}

	void OnEnable() {
		playerPos = GameObject.FindWithTag("Player").transform;
	}

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = playerPos.position;
	}

	public void CollisionHit () 
	{
		FindObjectOfType<GameManager>().CurrentScore = points;
		Destroy(this.gameObject);
	}

	void OnDisable() {
		
	}

}

public class CommonEnemyBehavior : EnemyBehavior {
	
	[SerializeField]
	private Mesh commonEnemyMesh;

}

public class PoliceEnemyBehavior : EnemyBehavior {

	[SerializeField]
	private Mesh policeEnemyMesh;

}

public class RiotEnemyBehavior : EnemyBehavior {

	[SerializeField]
	private Mesh riotEnemyMesh;

}