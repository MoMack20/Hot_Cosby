using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class controller_ai : MonoBehaviour {

	// Use this for initialization
	[HideInInspector] public NavMeshAgent agent;
	public List<GameObject> PatrolPoints = new List<GameObject>();
 	public IAI_state curState;
	[HideInInspector] public IAI_state patrolState;
	[HideInInspector] public IAI_state chaseState;
	[HideInInspector] public IAI_state idleState;
	[HideInInspector] public Vector3 startTransform;
	void Awake () {
		patrolState = new AI_patrol (this);
		chaseState = new AI_chase (this);
		idleState = new AI_idle (this);

		startTransform = transform.position;
		Debug.Log ("Start point: " + startTransform.ToString ());

		agent = GetComponent<NavMeshAgent> ();

		agent.destination = PatrolPoints [0].transform.position;
	}

	void Start() {
		patrolState.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (curState.ToString ());
		curState.UpdateState ();
	}

	void OnTriggerStay(Collider other) {
		curState.OnTriggerStay (other);
	}

	void OnTriggerExit(Collider other) {
		curState.OnTriggerExit (other);
	}
}
