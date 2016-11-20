using UnityEngine;
using System.Collections;

public class AI_chase : IAI_state {

	private controller_ai controller;
	private Vector3 curTarget;
	private bool playerInSight;
	private Vector3 lastKnownVelocity;

	public AI_chase(controller_ai c) {
		controller = c;
	}

	public void Start() {

	}

	public void Start(Vector3 target) {
		controller.curState = this;
		curTarget = target;
		controller.agent.destination = target;
		playerInSight = true;
	}

	public void UpdateState () {
		controller.agent.destination = curTarget;
		if (Vector3.Distance (curTarget, controller.transform.position) < 1.0) {
			if (playerInSight == true) {
				controller.transform.position = controller.startTransform;
				controller.patrolState.Start ();
			}
			else
				controller.idleState.Start(lastKnownVelocity);
		}
	}

	public void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player")) {
			Vector3 pos = controller.gameObject.transform.position;
			Ray ray = new Ray (pos, (other.transform.position - pos).normalized);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.CompareTag ("Player")) {
					playerInSight = true;
					curTarget = hit.transform.position;
				}
			}
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player") && playerInSight) {
			playerInSight = false;
			lastKnownVelocity = other.GetComponent<Rigidbody> ().velocity;
		}
	}
}
