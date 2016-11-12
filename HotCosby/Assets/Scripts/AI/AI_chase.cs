﻿using UnityEngine;
using System.Collections;

public class AI_chase : IAI_state {

	private controller_ai controller;
	private Vector3 curTarget;
	private bool playerInSight;

	public AI_chase(controller_ai c) {
		controller = c;
		playerInSight = false;
	}

	public void Start() {

	}

	public void Start(Vector3 target) {
		controller.curState = this;
		curTarget = target;
		controller.agent.destination = target;
		playerInSight = true;
		Debug.Log ("see player");
	}

	public void UpdateState () {
		controller.agent.destination = curTarget;
		if (Vector3.Distance (curTarget, controller.transform.position) < 1.0) {
			Debug.Log ("Got Target");
			if(playerInSight)
				controller.transform.position = controller.startTransform;
			controller.patrolState.Start ();
		}
	}

	public void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player")) {
			Vector3 pos = controller.gameObject.transform.position;
			Ray ray = new Ray (pos, (other.transform.position - pos).normalized);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.CompareTag ("Player")) {
					curTarget = hit.transform.position;
					Debug.Log ("pursuing player");
				}
			}
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player") && playerInSight)
			playerInSight = false;
	}
}