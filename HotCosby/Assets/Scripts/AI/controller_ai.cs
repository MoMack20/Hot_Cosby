using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class controller_ai : MonoBehaviour {

	// Use this for initialization
	[HideInInspector] public NavMeshAgent agent;
	public List<GameObject> PatrolPoints = new List<GameObject>();
	[HideInInspector] public IAI_state curState;
	[HideInInspector] public IAI_state patrolState;
	[HideInInspector] public IAI_state chaseState;
	void Awake () {
		patrolState = new AI_patrol (this);

		agent = GetComponent<NavMeshAgent> ();

		agent.destination = PatrolPoints [0].transform.position;
	}

	void Start() {
		patrolState.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		curState.UpdateState ();
	}

	void OnTriggerStay(Collider other) {
		curState.OnTriggerStay (other);
	}
}
